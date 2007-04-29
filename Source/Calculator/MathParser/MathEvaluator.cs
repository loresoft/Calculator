using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace Calculator.MathParser
{
    public class MathEvaluator
    {
        public const string AnswerVariable = "answer";

        public MathEvaluator()
        {
            _variables = new VariableCollection(this);
            _innerFunctions = new List<string>(FunctionExpression.MathFunctions);
            _functions = new ReadOnlyCollection<string>(_innerFunctions);
            _customFunctions = new Dictionary<string, IExpression>(StringComparer.OrdinalIgnoreCase);
        }

        private VariableCollection _variables;

        public VariableCollection Variables
        {
            get { return _variables; }
        }

        private Dictionary<string, IExpression> _customFunctions;
        private List<string> _innerFunctions;
        private ReadOnlyCollection<string> _functions;
        
        public ReadOnlyCollection<string> Functions
        {
            get { return _functions; }
        }

        public double Evaluate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException("expression");

            ExpressionQueue queue = InfixToPostfix(expression);
            double result = EvaluateQueue(queue);

            _variables[AnswerVariable] = result;
            return result;
        }

        public void RegisterFunction(string functionName, IExpression expression)
        {
            if (string.IsNullOrEmpty(functionName))
                throw new ArgumentNullException("functionName");
            if (expression == null)
                throw new ArgumentNullException("expression");
            if (expression.Evaluate == null)
                throw new ArgumentException("The IExpression.Evaluate property can not be null.", "expression");
            if (_innerFunctions.BinarySearch(functionName) >= 0)
                throw new ArgumentException(string.Format("The function name '{0}' is already registered.", functionName), "functionName");

            _innerFunctions.Add(functionName);
            _innerFunctions.Sort();
            _customFunctions.Add(functionName, expression);            
        }

        internal bool IsFunction(string name)
        {
            return (_innerFunctions.BinarySearch(name, StringComparer.OrdinalIgnoreCase) >= 0);
        }

        private ExpressionQueue InfixToPostfix(string expression)
        {
            ExpressionQueue queue = new ExpressionQueue();
            StringReader sr = new StringReader(expression);
            Stack<string> stack = new Stack<string>();

            do
            {
                char c = (char)sr.Read();
                string s = c.ToString();

                if (char.IsWhiteSpace(c))
                    continue;

                if (TryNumber(sr, c, queue))
                    continue;

                if (TryString(sr, stack, c, queue))
                    continue;

                if (TryStartGroup(stack, s))
                    continue;

                if (TryOperator(stack, s, queue))
                    continue;

                if (TryEndGroup(stack, c, queue))
                    continue;

                throw new ParseException("Invalid character encountered: " + c);

            } while (sr.Peek() != -1);

            CleanStack(stack, queue);

            return queue;
        }

        private bool TryString(StringReader sr, Stack<string> stack, char c, ExpressionQueue queue)
        {
            if (!char.IsLetter(c))
                return false;

            StringBuilder buffer = new StringBuilder();
            buffer.Append(c);

            char p = (char)sr.Peek();
            while (char.IsLetter(p))
            {
                buffer.Append((char)sr.Read());
                p = (char)sr.Peek();
            }

            if (_variables.ContainsKey(buffer.ToString()))
            {
                double value = _variables[buffer.ToString()];
                NumberExpression expression = new NumberExpression(value);
                queue.Enqueue(expression);

                return true;
            }

            if (IsFunction(buffer.ToString()))
            {
                stack.Push(buffer.ToString());
                return true;
            }

            throw new ParseException("Invalid function or variable encountered: " + buffer);
        }

        private bool TryStartGroup(Stack<string> stack, string c)
        {
            if (string.IsNullOrEmpty(c) || c[0] != '(')
                return false;

            stack.Push(c);
            return true;
        }

        private bool TryEndGroup(Stack<string> stack, char c, ExpressionQueue queue)
        {
            if (c != ')')
                return false;

            bool ok = false;

            while (stack.Count > 0)
            {
                string p = stack.Pop();
                if (p == "(")
                {
                    ok = true;
                    break;
                }
                
                IExpression e = GetExpressionFromStack(p);
                queue.Enqueue(e);
            }

            if (!ok)
                throw new ParseException("Unbalanced parentheses.");

            return true;

        }

        private bool TryOperator(Stack<string> stack, string c, ExpressionQueue queue)
        {
            if (!OperatorExpression.IsSymbol(c))
                return false;

            bool repeat;

            do
            {
                string p = stack.Count == 0 ? string.Empty : stack.Peek();
                repeat = false;
                if (stack.Count == 0)
                    stack.Push(c);
                else if (p == "(")
                    stack.Push(c);
                else if (Precedence(c) > Precedence(p))
                    stack.Push(c);
                else
                {
                    IExpression e = GetExpressionFromStack(stack.Pop());
                    queue.Enqueue(e);
                    repeat = true;
                }
            } while (repeat);

            return true;
        }

        private bool TryNumber(StringReader sr, char c, ExpressionQueue queue)
        {
            bool isNumber = NumberExpression.IsNumber(c);
            bool isNegative = queue.Count == 0 && NumberExpression.IsNegativeSign(c);

            if (!isNumber && !isNegative)
                return false;

            StringBuilder number = new StringBuilder();
            number.Append(c);

            char p = (char)sr.Peek();
            while (NumberExpression.IsNumber(p))
            {
                number.Append((char)sr.Read());
                p = (char)sr.Peek();
            }

            double value;
            if (!(double.TryParse(number.ToString(), out value)))
                throw new ParseException("Invalid Number: " + number.ToString());

            NumberExpression expression = new NumberExpression(value);
            queue.Enqueue(expression);

            return true;
        }

        private void CleanStack(Stack<string> stack, ExpressionQueue queue)
        {
            while (stack.Count > 0)
            {
                string p = stack.Pop();
                if (p == "(")
                    throw new ParseException("Unbalanced parentheses.");

                IExpression e = GetExpressionFromStack(p);
                queue.Enqueue(e);
            }
        }

        private IExpression GetExpressionFromStack(string p)
        {
            IExpression e = null;
            if (OperatorExpression.IsSymbol(p))
                e = new OperatorExpression(p);
            else if (FunctionExpression.IsFunction(p))
                e = new FunctionExpression(p, false);
            else if (_customFunctions.ContainsKey(p))
                e = _customFunctions[p];
            else
                throw new ParseException("Invaild symbol on stack: " + p);
            
            return e;
        }

        private static int Precedence(string c)
        {
            if (c == "*" || c == "/" || c == "%")
                return 2;
            //else if (c == "+" || c == "-" || c == "^")
            
            return 1;

            //throw new ParseException("Invalid math symbol: " + c); //should not happen
        }

        private double EvaluateQueue(ExpressionQueue queue)
        {
            double result = 0;

            Stack<double> stack = new Stack<double>();
            List<double> args = new List<double>(2);

            foreach (IExpression expression in queue)
            {
                args.Clear();
                for (int i = 0; i < expression.ArgumentCount; i++)
                    args.Insert(0, stack.Pop());

                stack.Push(expression.Evaluate.Invoke(args.ToArray()));
            }

            result = stack.Pop();
            return result;
        }
    }
}
