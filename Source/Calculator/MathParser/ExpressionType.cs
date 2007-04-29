using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.MathParser
{
    public enum ExpressionType
    {
        Number,
        Operator,
        Function,
        Conversion,
        BeginGroup,
        EndGroup
    }
}
