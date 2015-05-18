using System;
using System.Collections.Generic;
using System.Text;
using LoreSoft.MathExpressions;
using NUnit.Framework;

namespace  LoreSoft.MathExpressions.Tests
{
    [TestFixture()]
    public class ConvertExpressionTest
    {
        [SetUp()]
        public void Setup()
        {
            //TODO: NUnit setup
        }

        [TearDown()]
        public void TearDown()
        {
            //TODO: NUnit TearDown
        }

        [Test()]
        public void IsConvertExpression()
        {
            bool result = ConvertExpression.IsConvertExpression("blah");
            Assert.IsFalse(result);

            result = ConvertExpression.IsConvertExpression("[m->ft]");
            Assert.IsTrue(result);

            result = ConvertExpression.IsConvertExpression("[ms->ft]");
            Assert.IsFalse(result);

        }

        [Test]
        public void Convert()
        {
            ConvertExpression e = new ConvertExpression("[in->ft]");
            Assert.IsNotNull(e);

            double feet = e.Convert(new double[] { 12d });
            Assert.AreEqual(1, feet);
        }
    }
}
