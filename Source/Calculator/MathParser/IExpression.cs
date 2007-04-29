using System;

namespace Calculator.MathParser
{
    public interface IExpression
    {
        ExpressionType ExpressionType { get; }
        int ArgumentCount { get; }
        MathEvaluate Evaluate { get; set; }
    }
}
