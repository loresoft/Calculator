using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace  LoreSoft.Calculator.Tests
{
    [TestFixture()]
    public class JScriptEvalTest
    {
        [Test()]
        public void EvaluateSimple()
        {
            JScript.Evalulator eval = new JScript.Evalulator();
            double expected = (2d + 1d) * (1d + 2d);
            double result = double.Parse(eval.Eval("(2 + 1) * (1 + 2)"));

            Assert.AreEqual(expected, result);

            expected = 2d + 1d * 1d + 2d;
            result = double.Parse(eval.Eval("2 + 1 * 1 + 2"));

            Assert.AreEqual(expected, result);

            expected = 1d / 2d;
            result = double.Parse(eval.Eval("1/2"));

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void EvaluateComplex()
        {
            JScript.Evalulator eval = new JScript.Evalulator();
            double expected = ((1d + 2d) + 3d) * 2d - 8d / 4d;
            double result = double.Parse(eval.Eval("((1+2)+3)*2-8/4"));

            Assert.AreEqual(expected, result);

            expected = 3d + 4d / 5d - 8d;
            result = double.Parse(eval.Eval("3+4/5-8"));

            Assert.AreEqual(expected, result);

            expected = Math.Pow(1, 2) + 5 * 1 + 14;
            result = double.Parse(eval.Eval("1 ^ 2 + 5 * 1 + 14"));

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void EvaluateComplexPower()
        {
            JScript.Evalulator eval = new JScript.Evalulator();
            double expected = Math.Pow(1, 2) + 5 * 1 + 14;
            double result = double.Parse(eval.Eval("1 ^ 2 + 5 * 1 + 14"));

            Assert.AreEqual(expected, result);
        }
    }
}
