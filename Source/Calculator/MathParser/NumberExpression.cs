using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Calculator.MathParser
{
    public class NumberExpression : ExpressionBase
    {
        public NumberExpression(double value)
        {
            _value = value;
            Evaluate = delegate(double[] numbers)
            {
                return this.Value;
            };
        }

        public override int ArgumentCount
        {
            get { return 0; }
        }

        public override ExpressionType ExpressionType
        {
            get { return ExpressionType.Number; }
        }

        private double _value;

        public double Value
        {
            get { return _value; }
        }

        public static bool IsNumber(char c)
        {
            NumberFormatInfo f = CultureInfo.CurrentUICulture.NumberFormat;
            return char.IsDigit(c) || f.NumberDecimalSeparator.IndexOf(c) >= 0;
        }

        public static bool IsNegativeSign(char c)
        {
            NumberFormatInfo f = CultureInfo.CurrentUICulture.NumberFormat;
            return f.NegativeSign.IndexOf(c) >= 0;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
