using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.MathParser
{
    public enum MathOperators
    {
        Add,
        Subtract,
        Multiple,
        Divide,
        Modulo,
        Power
    }

    public class OperatorExpression : ExpressionBase
    {
        public static readonly char[] OperatorSymbols = new char[] { '+', '-', '*', '/', '%', '^' };

        public OperatorExpression(string @operator)
        {
            //TODO refactor into dictionary
            switch (@operator)
            {
                case "+":
                    base.Evaluate = new MathEvaluate(this.Add);
                    _mathOperator = MathOperators.Add;
                    break;
                case "-":
                    base.Evaluate = new MathEvaluate(this.Subtract);
                    _mathOperator = MathOperators.Subtract;
                    break;
                case "*":
                    base.Evaluate = new MathEvaluate(this.Multiple);
                    _mathOperator = MathOperators.Multiple;
                    break;
                case "/":
                    base.Evaluate = new MathEvaluate(this.Divide);
                    _mathOperator = MathOperators.Divide;
                    break;
                case "%":
                    base.Evaluate = new MathEvaluate(this.Modulo);
                    _mathOperator = MathOperators.Modulo;
                    break;
                case "^":
                    base.Evaluate = new MathEvaluate(this.Power);
                    _mathOperator = MathOperators.Power;
                    break;
                
                default:
                    throw new ArgumentException("Invaild operator: " + @operator, "operator");
            }
        }

        private MathOperators _mathOperator;

        public MathOperators MathOperator
        {
            get { return _mathOperator; }
        }

        public override int ArgumentCount
        {
            get { return 2; }
        }

        public override ExpressionType ExpressionType
        {
            get { return ExpressionType.Operator; }
        }

        public double Add(double[] numbers)
        {
            base.Validate(numbers);
            double result = 0;
            foreach (double n in numbers)
                result += n;

            return result;
        }

        public double Subtract(double[] numbers)
        {
            base.Validate(numbers);
            double? result = null;
            foreach (double n in numbers)
                if (result.HasValue)
                    result -= n;
                else
                    result = n;

            return result.Value;
        }

        public double Multiple(double[] numbers)
        {
            base.Validate(numbers);
            double? result = null;
            foreach (double n in numbers)
                if (result.HasValue)
                    result *= n;
                else
                    result = n;

            return result.Value;
        }

        public double Divide(double[] numbers)
        {
            base.Validate(numbers);
            double? result = null;
            foreach (double n in numbers)
                if (result.HasValue)
                    result /= n;
                else
                    result = n;

            return result.Value;
        }

        public double Modulo(double[] numbers)
        {
            base.Validate(numbers);
            double? result = null;
            foreach (double n in numbers)
                if (result.HasValue)
                    result %= n;
                else
                    result = n;

            return result.Value;
        }

        public double Power(double[] numbers)
        {
            base.Validate(numbers);
            return Math.Pow(numbers[0], numbers[1]);
        }
        
        public static bool IsSymbol(string c)
        {
            if (c == null || c.Length != 1)
                return false;

            return IsSymbol(c[0]);
        }

        public static bool IsSymbol(char c)
        {
            return Array.Exists<char>(OperatorSymbols, delegate(char s) { return s == c; });
        }

        public override string ToString()
        {
            return _mathOperator.ToString();
        }
    }
}
