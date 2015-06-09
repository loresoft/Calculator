using System;
using System.Collections.Generic;
using System.Text;
using LoreSoft.MathExpressions.UnitConversion;
using NUnit.Framework;

namespace LoreSoft.MathExpressions.Tests.UnitConversion
{
    [TestFixture()]
    public class LengthConverterTest
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
        public void Convert()
        {
            double result = LengthConverter.Convert(
                LengthUnit.Feet, LengthUnit.Inch, 1);
            Assert.AreEqual(12, result);

            result = LengthConverter.Convert(
                LengthUnit.Inch, LengthUnit.Feet, 12);
            Assert.AreEqual(1, result);

            result = LengthConverter.Convert(
                LengthUnit.Mile, LengthUnit.Kilometer, 10);
            Assert.AreEqual(16.09344, result);

            result = LengthConverter.Convert(
                LengthUnit.Meter, LengthUnit.Feet, 10);
            Assert.AreEqual(32.808398950131235, result);
        }
    }
}
