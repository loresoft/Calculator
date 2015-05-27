using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using LoreSoft.MathExpressions.Properties;
using System.Globalization;
using System.Linq;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// Evaluate math expressions
    /// </summary>
    /// <example>Using the MathEvaluator to calculate a math expression.
    /// <code>
    /// MathEvaluator eval = new MathEvaluator();
    /// //basic math
    /// double result = eval.Evaluate("(2 + 1) * (1 + 2)");
    /// //calling a function
    /// result = eval.Evaluate("sqrt(4)");
    /// //evaluate trigonometric 
    /// result = eval.Evaluate("cos(pi * 45 / 180.0)");
    /// //convert inches to feet
    /// result = eval.Evaluate("12 [in->ft]");
    /// //use variable
    /// result = eval.Evaluate("answer * 10");
    /// </code>
    /// </example>
    public class MathEvaluator : IDisposable
    {
        /// <summary>The name of the answer variable.</summary>
        /// <seealso cref="Variables"/>
        public const string AnswerVariable = "answer";

        //instance scope to optimize reuse
        private Stack<string> _symbolStack;
        private Queue<IExpression> _expressionQueue;
        private Dictionary<string, IExpression> _expressionCache;
        private StringBuilder _buffer;
        private Stack<double> _calculationStack;
        private Stack<double> _parameters;
        private List<string> _innerFunctions;
        private uint _nestedFunctionDepth;
        private uint _nestedGroupDepth;
        private StringReader _expressionReader;
        private VariableDictionary _variables;
        private ReadOnlyCollection<string> _functions;        
        private char _currentChar;


        /// <summary>
        /// Initializes a new instance of the <see cref="MathEvaluator"/> class.
        /// </summary>
        public MathEvaluator()
        {
            _variables = new VariableDictionary(this);
            _innerFunctions = new List<string>(FunctionExpression.GetFunctionNames());
            _innerFunctions.Sort();
            _functions = new ReadOnlyCollection<string>(_innerFunctions);
            _expressionCache = new Dictionary<string, IExpression>(StringComparer.OrdinalIgnoreCase);
            _symbolStack = new Stack<string>();
            _expressionQueue = new Queue<IExpression>();
            _buffer = new StringBuilder();
            _calculationStack = new Stack<double>();
            _parameters = new Stack<double>(2);
            _nestedFunctionDepth = 0;
            _nestedGroupDepth = 0;
        }


        /// <summary>
        /// Gets the variables collections.
        /// </summary>
        /// <value>The variables for <see cref="MathEvaluator"/>.</value>
        public VariableDictionary Variables
        {
            get { return _variables; }
        }

        /// <summary>Gets the functions available to <see cref="MathEvaluator"/>.</summary>
        /// <value>The functions for <see cref="MathEvaluator"/>.</value>
        /// <seealso cref="RegisterFunction"/>
        public ReadOnlyCollection<string> Functions
        {
            get { return _functions; }
        }

        /// <summary>Gets the answer from the last evaluation.</summary>
        /// <value>The answer variable value.</value>
        /// <seealso cref="Variables"/>
        public double Answer
        {
            get { return _variables[AnswerVariable]; }
        }

        /// <summary>Evaluates the specified expression.</summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>The result of the evaluated expression.</returns>
        /// <exception cref="ArgumentNullException">When expression is null or empty.</exception>
        /// <exception cref="ParseException">When there is an error parsing the expression.</exception>
        public double Evaluate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException("expression");

            _expressionReader = new StringReader(expression);
            _symbolStack.Clear();
            _nestedFunctionDepth = 0;
            _nestedGroupDepth = 0;
            _expressionQueue.Clear();

            ParseExpressionToQueue();

            double result = CalculateFromQueue();

            _variables[AnswerVariable] = result;
            return result;
        }

        /// <summary>Registers a function for the <see cref="MathEvaluator"/>.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="expression">An instance of <see cref="IExpression"/> for the function.</param>
        /// <exception cref="ArgumentNullException">When functionName or expression are null.</exception>
        /// <exception cref="ArgumentException">When IExpression.Evaluate property is null or the functionName is already registered.</exception>
        /// <seealso cref="Functions"/>
        /// <seealso cref="IExpression"/>
        public void RegisterFunction(string functionName, IExpression expression)
        {
            if (string.IsNullOrEmpty(functionName))
                throw new ArgumentNullException("functionName");
            if (expression == null)
                throw new ArgumentNullException("expression");
            if (expression.Evaluate == null)
                throw new ArgumentException(Resources.EvaluatePropertyCanNotBeNull, "expression");
            if (_innerFunctions.BinarySearch(functionName) >= 0)
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture,
                        Resources.FunctionNameRegistered, functionName), "functionName");

            _innerFunctions.Add(functionName);
            _innerFunctions.Sort();
            _expressionCache.Add(functionName, expression);
        }

        /// <summary>Determines whether the specified name is a function.</summary>
        /// <param name="name">The name of the function.</param>
        /// <returns><c>true</c> if the specified name is function; otherwise, <c>false</c>.</returns>
        internal bool IsFunction(string name)
        {
            return (_innerFunctions.BinarySearch(name, StringComparer.OrdinalIgnoreCase) >= 0);
        }

        private void ParseExpressionToQueue()
        {
            char lastChar = '\0'; 
            _currentChar = '\0';

            do
            {
                // last non white space char
                if (!char.IsWhiteSpace(_currentChar))
                    lastChar = _currentChar;

                _currentChar = (char)_expressionReader.Read();

                if (char.IsWhiteSpace(_currentChar))
                    continue;

                if (TryNumber(lastChar))
                    continue;

                if (TryString())
                    continue;

                if (TryStartGroup())
                    continue;

                if (TryComma())
                    continue;

                if (TryOperator())
                    continue;

                if (TryEndGroup())
                    continue;

                if (TryConvert())
                    continue;

                throw new ParseException(Resources.InvalidCharacterEncountered + _currentChar);
            } while (_expressionReader.Peek() != -1);

            ProcessSymbolStack();
        }

        private bool TryConvert()
        {
            if (_currentChar != '[')
                return false;

            _buffer.Length = 0;
            _buffer.Append(_currentChar);

            char p = (char)_expressionReader.Peek();
            while (char.IsLetter(p) || char.IsWhiteSpace(p) || p == '-' || p == '>' || p == ']')
            {
                if (!char.IsWhiteSpace(p))
                    _buffer.Append((char)_expressionReader.Read());
                else
                    _expressionReader.Read();

                if (p == ']')
                    break;

                p = (char)_expressionReader.Peek();
            }

            if (ConvertExpression.IsConvertExpression(_buffer.ToString()))
            {
                IExpression e = GetExpressionFromSymbol(_buffer.ToString());
                _expressionQueue.Enqueue(e);
                return true;
            }

            throw new ParseException(Resources.InvalidConvertionExpression + _buffer);
        }

        private bool TryString()
        {
            if (!char.IsLetter(_currentChar))
                return false;

            _buffer.Length = 0;
            _buffer.Append(_currentChar);

            char p = (char)_expressionReader.Peek();
            while (char.IsLetter(p) || char.IsNumber(p))
            {
                _buffer.Append((char)_expressionReader.Read());
                p = (char)_expressionReader.Peek();
            }

            if (_variables.ContainsKey(_buffer.ToString()))
            {
                double value = _variables[_buffer.ToString()];
                NumberExpression expression = new NumberExpression(value);
                _expressionQueue.Enqueue(expression);

                return true;
            }

            if (IsFunction(_buffer.ToString()))
            {
                _symbolStack.Push(_buffer.ToString());
                _nestedFunctionDepth++;
                return true;
            }

            throw new ParseException(Resources.InvalidVariableEncountered + _buffer);
        }

        private bool TryStartGroup()
        {
            if (_currentChar != '(')
                return false;

            if (PeekNextNonWhitespaceChar() == ',')
            {
                throw new ParseException(Resources.InvalidCharacterEncountered + ",");
            }

            _symbolStack.Push(_currentChar.ToString());
            _nestedGroupDepth++;
            return true;
        }

        private bool TryComma()
        {
            if (_currentChar != ',')
                return false;

            if (_nestedFunctionDepth <= 0 ||
                _nestedFunctionDepth < _nestedGroupDepth)
            {
                throw new ParseException(Resources.InvalidCharacterEncountered + _currentChar);
            }
                        
            char nextChar = PeekNextNonWhitespaceChar();
            if (nextChar == ')' || nextChar == ',')
            {
                throw new ParseException(Resources.InvalidCharacterEncountered + _currentChar);
            }

            return true;
        }

        private char PeekNextNonWhitespaceChar()
        {
            int next = _expressionReader.Peek();
            while (next != -1 && char.IsWhiteSpace((char)next))
            {
                _expressionReader.Read();
                next = _expressionReader.Peek();
            }
            return (char)next;
        }

       
        private bool TryEndGroup()
        {
            if (_currentChar != ')')
                return false;

            bool hasStart = false;

             while (_symbolStack.Count > 0)
            {
                string p = _symbolStack.Pop();
                if (p == "(")
                {
                    hasStart = true;

                    if (_symbolStack.Count == 0)
                        break;

                    string n = _symbolStack.Peek();
                    if (IsFunction(n))
                    {
                        p = _symbolStack.Pop();
                        IExpression f = GetExpressionFromSymbol(p);
                        _expressionQueue.Enqueue(f);
                        _nestedFunctionDepth--;
                    }

                    _nestedGroupDepth--; 

                    break;
                }

                IExpression e = GetExpressionFromSymbol(p);
                _expressionQueue.Enqueue(e);
            }

            if (!hasStart)
                throw new ParseException(Resources.UnbalancedParentheses);

            return true;
        }

        private bool TryOperator()
        {
            if (!OperatorExpression.IsSymbol(_currentChar))
                return false;

            bool repeat;
            string s = _currentChar.ToString();

            do
            {
                string p = _symbolStack.Count == 0 ? string.Empty : _symbolStack.Peek();
                repeat = false;
                if (_symbolStack.Count == 0)
                    _symbolStack.Push(s);
                else if (p == "(")
                    _symbolStack.Push(s);
                else if (Precedence(s) > Precedence(p))
                    _symbolStack.Push(s);
                else
                {
                    IExpression e = GetExpressionFromSymbol(_symbolStack.Pop());
                    _expressionQueue.Enqueue(e);
                    repeat = true;
                }
            } while (repeat);

            return true;
        }

        private bool TryNumber(char lastChar)
        {
            bool isNumber = NumberExpression.IsNumber(_currentChar);
            // only negative when last char is group start or symbol
            bool isNegative = NumberExpression.IsNegativeSign(_currentChar) &&
                              (lastChar == '\0' || lastChar == '(' || OperatorExpression.IsSymbol(lastChar));

            if (!isNumber && !isNegative)
                return false;

            _buffer.Length = 0;
            _buffer.Append(_currentChar);

            char p = (char)_expressionReader.Peek();
            while (NumberExpression.IsNumber(p))
            {
                _currentChar = (char) _expressionReader.Read();
                _buffer.Append(_currentChar);
                p = (char)_expressionReader.Peek();
            }

            double value;
            if (!(double.TryParse(_buffer.ToString(), out value)))
                throw new ParseException(Resources.InvalidNumberFormat + _buffer);

            NumberExpression expression = new NumberExpression(value);
            _expressionQueue.Enqueue(expression);

            return true;
        }

        private void ProcessSymbolStack()
        {
            while (_symbolStack.Count > 0)
            {
                string p = _symbolStack.Pop();
                if (p.Length == 1 && p == "(")
                    throw new ParseException(Resources.UnbalancedParentheses);

                IExpression e = GetExpressionFromSymbol(p);
                _expressionQueue.Enqueue(e);
            }
        }

        private IExpression GetExpressionFromSymbol(string p)
        {
            IExpression e;

            if (_expressionCache.ContainsKey(p))
                e = _expressionCache[p];
            else if (OperatorExpression.IsSymbol(p))
            {
                e = new OperatorExpression(p);
                _expressionCache.Add(p, e);
            }
            else if (FunctionExpression.IsFunction(p))
            {
                e = new FunctionExpression(p, false);
                _expressionCache.Add(p, e);
            }
            else if (ConvertExpression.IsConvertExpression(p))
            {
                e = new ConvertExpression(p);
                _expressionCache.Add(p, e);
            }
            else
                throw new ParseException(Resources.InvalidSymbolOnStack + p);

            return e;
        }

        private static int Precedence(string c)
        {
            if (c.Length == 1 && (c[0] == '*' || c[0] == '/' || c[0] == '%'))
                return 2;

            return 1;
        }

        private double CalculateFromQueue()
        {
            double result;
            _calculationStack.Clear();

            foreach (IExpression expression in _expressionQueue)
            {
                if (_calculationStack.Count < expression.ArgumentCount)
                    throw new ParseException(Resources.NotEnoughNumbers + expression);

                _parameters.Clear();
                for (int i = 0; i < expression.ArgumentCount; i++)
                    _parameters.Push(_calculationStack.Pop());

                _calculationStack.Push(expression.Evaluate.Invoke(_parameters.ToArray()));
            }

            result = _calculationStack.Pop();

            if (_calculationStack.Any())
            {
                throw new ParseException(String.Format("{0}Items '{1}' were remaining on calculation stack.", Resources.InvalidSymbolOnStack, string.Join(", ", _calculationStack)));
            }

            return result;
        }

        #region IDisposable Members

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and  managed resources
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_expressionReader != null)
                {
                    _expressionReader.Dispose();
                    _expressionReader = null;
                }
            }
        }

        #endregion
        
    }
}