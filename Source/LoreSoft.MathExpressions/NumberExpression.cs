using System.Globalization;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// Class representing a constant number expression.
    /// </summary>
    public class NumberExpression : ExpressionBase
    {
        /// <summary>Initializes a new instance of the <see cref="NumberExpression"/> class.</summary>
        /// <param name="value">The number value for this expression.</param>
        public NumberExpression(double value)
        {
            _value = value;
            base.Evaluate = delegate
            {
                return Value;
            };
        }

        /// <summary>Gets the number of arguments this expression uses.</summary>
        /// <value>The argument count.</value>
        public override int ArgumentCount
        {
            get { return 0; }
        }

        private double _value;

        /// <summary>Gets the number value for this expression.</summary>
        /// <value>The number value.</value>
        public double Value
        {
            get { return _value; }
        }

        /// <summary>Determines whether the specified char is a number.</summary>
        /// <param name="c">The char to test.</param>
        /// <returns><c>true</c> if the specified char is a number; otherwise, <c>false</c>.</returns>
        /// <remarks>This method checks if the char is a digit or a decimal separator.</remarks>
        public static bool IsNumber(char c)
        {
            NumberFormatInfo f = CultureInfo.CurrentUICulture.NumberFormat;
            return char.IsDigit(c) || f.NumberDecimalSeparator.IndexOf(c) >= 0;
        }

        /// <summary>Determines whether the specified char is negative sign.</summary>
        /// <param name="c">The char to check.</param>
        /// <returns><c>true</c> if the specified char is negative sign; otherwise, <c>false</c>.</returns>
        public static bool IsNegativeSign(char c)
        {
            NumberFormatInfo f = CultureInfo.CurrentUICulture.NumberFormat;
            return f.NegativeSign.IndexOf(c) >= 0;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterPriority>2</filterPriority>
        public override string ToString()
        {
            return _value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
