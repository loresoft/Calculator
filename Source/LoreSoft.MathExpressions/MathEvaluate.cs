namespace LoreSoft.MathExpressions
{
    /// <summary>Delegate used by an expression to do the math evaluation.</summary>
    /// <param name="numbers">The numbers to evaluate.</param>
    /// <returns>The result of the evaluated numbers.</returns>
    public delegate double MathEvaluate(double[] numbers);
}
