using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LoreSoft.MathExpressions;

namespace LoreSoft.MathExpressions.Tests
{
    [TestFixture()]
    public class MathEvaluatorTest
    {
        private MathEvaluator eval;
            
        [SetUp()]
        public void Setup()
        {
            eval = new MathEvaluator();
        }

        [TearDown()]
        public void TearDown()
        {
            //TODO: NUnit TearDown
        }

        [Test()]
        public void EvaluateSimple()
        {
            double expected = (2d + 1d) * (1d + 2d);
            double result = eval.Evaluate("(2 + 1) * (1 + 2)");

            Assert.AreEqual(expected, result);

            expected = 2d + 1d * 1d + 2d;
            result = eval.Evaluate("2 + 1 * 1 + 2");

            Assert.AreEqual(expected, result);

            expected = 1d / 2d;
            result = eval.Evaluate("1/2");

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void EvaluateComplex()
        {
            double expected = ((1d + 2d) + 3d) * 2d - 8d / 4d;
            double result = eval.Evaluate("((1+2)+3)*2-8/4");

            Assert.AreEqual(expected, result);

            expected = 3d + 4d / 5d - 8d;
            result = eval.Evaluate("3+4/5-8");

            Assert.AreEqual(expected, result);

            expected = Math.Pow(1, 2) + 5 * 1 + 14;
            result = eval.Evaluate("1 ^ 2 + 5 * 1 + 14");

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void EvaluateComplexPower()
        {
            //TODO: Fix pow support
            double expected = Math.Pow(1, 2) + 5 * 1 + 14;
            double result = eval.Evaluate("1 ^ 2 + 5 * 1 + 14");

            Assert.AreEqual(expected, result);
        }

        [Test()]
        public void EvaluateFunctionSin()
        {
            double expected = Math.Sin(45);
            double result = eval.Evaluate("sin(45)");

            Assert.AreEqual(expected, result);

        }

        [Test()]
        public void EvaluateFunctionSinMath()
        {
            double expected = Math.Sin(45) + 45;
            double result = eval.Evaluate("sin(45) + 45");

            Assert.AreEqual(expected, result);

        }

        [Test()]
        public void EvaluateFunctionSinComplex()
        {
            double expected = 10 * Math.Sin(35 + 10) + 10;
            double result = eval.Evaluate("10 * sin(35 + 10) + 10");

            Assert.AreEqual(expected, result);

        }

        [Test()]
        public void EvaluateVariableComplex()
        {
            int i = 10;
            eval.Variables.Add("i", i);

            double expected = Math.Pow(i, 2) + 5 * i + 14;
            double result = eval.Evaluate("i^2+5*i+14");

            Assert.AreEqual(expected, result);

        }

        [Test()]
        public void EvaluateVariableLoop()
        {
            eval.Variables.Add("i", 0);
            double expected = 0;
            double result = 0;

            for (int i = 1; i < 100000; i++)
            {
                eval.Variables["i"] = i;
                expected += Math.Pow(i, 2) + 5 * i + 14;
                result += eval.Evaluate("i^2+5*i+14");
            }

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EvaluateConvert()
        {
            double expected = 12;
            double result = eval.Evaluate("1 [ft->in]");

            Assert.AreEqual(expected, result);

            expected = 12;
            result = eval.Evaluate("1 [ft -> in]");

            Assert.AreEqual(expected, result);
        }
    }
}
