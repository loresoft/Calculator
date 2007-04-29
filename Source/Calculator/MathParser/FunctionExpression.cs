using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Calculator.MathParser
{
    public class FunctionExpression : ExpressionBase
    {
        // must be sorted
        public static readonly string[] MathFunctions = new string[] { 
            "abs", "acos", "asin", "atan", "ceiling", "cos", "cosh", "exp",
            "floor", "log", "log10", "sin", "sinh", "sqrt", "tan", "tanh"};

        public FunctionExpression(string function) : this(function, true)
        { }

        internal FunctionExpression(string function, bool validate)
        {
            function = function.ToLowerInvariant();

            if (validate && !IsFunction(function))
                throw new ArgumentException("Invalid function name.", "function");

            _function = function;
            Evaluate = new MathEvaluate(Execute);
        }

        private string _function;

        public string Function
        {
            get { return _function; }
        }

        public double Execute(double[] numbers)
        {
            base.Validate(numbers);

            string function = char.ToUpper(_function[0]) + _function.Substring(1);
            MethodInfo method = typeof(Math).GetMethod(
                function, BindingFlags.Static | BindingFlags.Public);

            if (method == null)
                throw new InvalidOperationException(
                    string.Format("Invalid function name '{0}'.", _function));

            object[] parameters = new object[numbers.Length];
            Array.Copy(numbers, parameters, numbers.Length);
            return (double)method.Invoke(null, parameters);
        }

        public override int ArgumentCount
        {
            get { return 1; }
        }

        public override ExpressionType ExpressionType
        {
            get { return ExpressionType.Function; }
        }

        public static bool IsFunction(string function)
        {
            return (Array.BinarySearch<string>(
                MathFunctions, function, 
                StringComparer.OrdinalIgnoreCase) >= 0);
        }

        public override string ToString()
        {
            return _function;
        }

    }
}
