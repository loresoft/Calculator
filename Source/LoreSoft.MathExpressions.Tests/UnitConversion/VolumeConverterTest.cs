using System;
using System.Collections.Generic;
using System.Text;
using LoreSoft.MathExpressions.UnitConversion;
using NUnit.Framework;

namespace LoreSoft.MathExpressions.Tests.UnitConversion
{
    [TestFixture()]
    public class VolumeConverterTest
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
            double result = VolumeConverter.Convert(
                VolumeUnit.Gallon, VolumeUnit.Quart, 1);
            Assert.AreEqual(4, result);
        }
    }
}
