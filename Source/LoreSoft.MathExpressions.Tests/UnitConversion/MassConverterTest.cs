using System;
using System.Collections.Generic;
using System.Text;
using LoreSoft.MathExpressions.UnitConversion;
using NUnit.Framework;

namespace LoreSoft.MathExpressions.Tests.UnitConversion
{
    [TestFixture()]
    public class MassConverterTest
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
            double result = MassConverter.Convert(
                MassUnit.Ounce, MassUnit.Pound, 12);
            Assert.AreEqual(0.75, result);

            result = MassConverter.Convert(
                MassUnit.Pound, MassUnit.Ounce, 0.75);
            Assert.AreEqual(12, result);

            result = MassConverter.Convert(
                MassUnit.Kilogram, MassUnit.Pound, 1);
            Assert.AreEqual(2.2046226218487757d, result);

            result = MassConverter.Convert(
                MassUnit.Ton, MassUnit.Pound, 1);
            Assert.AreEqual(2000d, result);
        }
    }
}
