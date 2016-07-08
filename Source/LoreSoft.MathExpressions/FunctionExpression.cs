using System;
using System.Collections.Generic;
using System.Reflection;
using LoreSoft.MathExpressions.Properties;
using System.Globalization;
using System.Linq;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// A class representing the System.Math function expressions
    /// </summary>
    public class FunctionExpression : ExpressionBase
    {
        // must be sorted
        /// <summary>The supported single argument math functions by this class.</summary>
        private static readonly string[] oneArgumentMathFunctions = new string[]
            {
                "abs", "acos", "asin", "atan", "ceiling", "cos", "cosh", "exp",
                "floor", "log", "log10", "sin", "sinh", "sqrt", "tan", "tanh"
            };

        // must be sorted
        /// <summary>The supported two argument math functions by this class.</summary>
        private static readonly string[] twoArgumentMathFunctions = new string[]
            {
                "max", "min", "pow", "round"
            };

        /// <summary>Initializes a new instance of the <see cref="FunctionExpression"/> class.</summary>
        /// <param name="function">The function name for this instance.</param>
        public FunctionExpression(string function) : this(function, true)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FunctionExpression"/> class.</summary>
        /// <param name="function">The function.</param>
        /// <param name="validate">if set to <c>true</c> to validate the function name.</param>
        internal FunctionExpression(string function, bool validate)
        {
            function = function.ToLowerInvariant();

            if (validate && !IsFunction(function))
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidFunctionName, _function),
                    "function");

            _function = function;
            base.Evaluate = new MathEvaluate(Execute);
        }

        private string _function;

        /// <summary>Gets the name function for this instance.</summary>
        /// <value>The function name.</value>
        public string Function
        {
            get { return _function; }
        }

        /// <summary>Executes the function on specified numbers.</summary>
        /// <param name="numbers">The numbers used in the function.</param>
        /// <returns>The result of the function execution.</returns>
        /// <exception cref="ArgumentNullException">When numbers is null.</exception>
        /// <exception cref="ArgumentException">When the length of numbers do not equal <see cref="ArgumentCount"/>.</exception>
        public double Execute(double[] numbers)
        {
            base.Validate(numbers);

            Type[] desiredMethodSignatureArgs = {typeof (double)};

            if (IsTwoArgumentFunction(_function))
            {
                desiredMethodSignatureArgs = new []{typeof (double), typeof (double)};
            }

            string function = char.ToUpperInvariant(_function[0]) + _function.Substring(1);
            MethodInfo method = typeof (Math).GetMethod(
                function, 
                BindingFlags.Static | BindingFlags.Public,
                null,
                desiredMethodSignatureArgs,
                null);

            if (method == null)
                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture, 
                        Resources.InvalidFunctionName, _function));

            object[] parameters = new object[numbers.Length];
            Array.Copy(numbers, parameters, numbers.Length);
            return (double) method.Invoke(null, parameters);
        }

        /// <summary>Gets the number of arguments this expression uses.</summary>
        /// <value>The argument count.</value>
        public override int ArgumentCount
        {
            get
            {
                int rval = 1;

                if (IsTwoArgumentFunction(_function))
                {
                    rval = 2;
                }

                return rval;
            }
        }

        /// <summary>Determines whether the specified function name is a function.</summary>
        /// <param name="function">The function name.</param>
        /// <returns><c>true</c> if the specified name is a function; otherwise, <c>false</c>.</returns>
        public static bool IsFunction(string function)
        {
            return IsOneArgumentFunction(function) || IsTwoArgumentFunction(function);
        }

        private static bool IsTwoArgumentFunction(string function)
        {
            bool isTwoArgumentFunction = Array.BinarySearch(
                twoArgumentMathFunctions, function,
                StringComparer.OrdinalIgnoreCase) >= 0;
            return isTwoArgumentFunction;
        }

        private static bool IsOneArgumentFunction(string function)
        {
            bool isOneArgumentFunction = Array.BinarySearch(
                oneArgumentMathFunctions, function,
                StringComparer.OrdinalIgnoreCase) >= 0;
            return isOneArgumentFunction;
        }

        /// <summary>Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.</summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.</returns>
        /// <filterPriority>2</filterPriority>
        public override string ToString()
        {
            return _function;
        }

        /// <summary>
        /// Gets the function names.
        /// </summary>
        /// <returns>An array of function names.</returns>
        public static string[] GetFunctionNames()
        {
            return oneArgumentMathFunctions.Concat(twoArgumentMathFunctions).ToArray();
        }
    }
}