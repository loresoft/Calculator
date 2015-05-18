using System;
using System.Collections.Generic;
using System.Text;
using LoreSoft.MathExpressions.UnitConversion;
using NUnit.Framework;

namespace LoreSoft.MathExpressions.Tests.UnitConversion
{
    [TestFixture()]
    public class TemperatureConverterTest
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
            double result = TemperatureConverter.Convert(
                TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -40d);
            Assert.AreEqual(-40, result);

            result = TemperatureConverter.Convert(
                TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 0);
            Assert.AreEqual(32, result);

            result = TemperatureConverter.Convert(
                TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 212);
            Assert.AreEqual(100, result);

            result = TemperatureConverter.Convert(
                TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin, 212);
            Assert.AreEqual(373.15, result);
        }
    }
}
