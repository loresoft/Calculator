using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.MathParser
{

    public abstract class ExpressionBase : IExpression
    {

        public abstract int ArgumentCount { get; }

        public abstract ExpressionType ExpressionType { get; }

        private MathEvaluate _evalulateDelegate;

        public virtual MathEvaluate Evaluate
        {
            get { return _evalulateDelegate; }
            set { _evalulateDelegate = value; }
        }

        protected void Validate(double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("numbers");
            if (numbers.Length != this.ArgumentCount)
                throw new ArgumentException("Invalid length of array.", "numbers");
        }



    }
}
