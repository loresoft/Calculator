using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LoreSoft.MathExpressions.Metadata;
using LoreSoft.MathExpressions.UnitConversion;

namespace LoreSoft.MathExpressions.Tests.Metadata
{
    [TestFixture()]
    public class AttributeReaderTest
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
        public void GetDescription()
        {
            string result = AttributeReader.GetDescription<SpeedUnit>(SpeedUnit.MilePerHour);
            Assert.AreEqual("Mile/Hour", result);

            result = AttributeReader.GetDescription<SpeedUnit>(SpeedUnit.Knot);
            Assert.AreEqual("Knot", result);


           
        }

        [Test()]
        public void GetAbbreviation()
        {
            string result = AttributeReader.GetAbbreviation<SpeedUnit>(SpeedUnit.MilePerHour);
            Assert.AreEqual("mph", result);

            result = AttributeReader.GetAbbreviation<SpeedUnit>(SpeedUnit.Knot);
            Assert.AreEqual("knot", result);



        }
    }
}
