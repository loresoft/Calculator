using LoreSoft.MathExpressions.Metadata;
using System.ComponentModel;
namespace LoreSoft.MathExpressions.UnitConversion
{
    /// <summary>Units for Speed</summary>
    public enum SpeedUnit
    {
        /// <summary>Meter/Second unit (m/s)</summary>
        [Abbreviation("m/s")]
        [Description("Meter/Second")]
        MeterPerSecond = 0,
        /// <summary>Kilometer/Hour unit (kph)</summary>
        [Abbreviation("kph")]
        [Description("Kilometer/Hour")]
        KilometerPerHour = 1,
        /// <summary>Foot/Second unit (ft/s)</summary>
        [Abbreviation("ft/s")]
        [Description("Foot/Second")]
        FootPerSecond = 2,
        /// <summary>Mile/Hour unit (mph)</summary>
        [Abbreviation("mph")]
        [Description("Mile/Hour")]
        MilePerHour = 3,
        /// <summary>Knot unit (knot)</summary>
        [Abbreviation("knot")]
        Knot = 4,
        /// <summary>Mach unit (mach)</summary>
        [Abbreviation("mach")]
        Mach = 5,
    }

    /// <summary>
    /// Class representing speed convertion.
    /// </summary>
    public static class SpeedConverter
    {
        // In enum order
        private static readonly double[] factors = new double[]
            {
                1d,                         //meter/second
                1000d/3600d,                //kilometer/hour
                0.3048d,                    //foot/second
                (0.3048d*5280d)/3600d,      //mile/hour (mph)
                1852d/3600d,                //knot
                340.29d,                    //mach
            };


        /// <summary>
        /// Converts the specified from unit to the specified unit.
        /// </summary>
        /// <param name="fromUnit">Covert from unit.</param>
        /// <param name="toUnit">Covert to unit.</param>
        /// <param name="fromValue">Covert from value.</param>
        /// <returns>The converted value.</returns>
        public static double Convert(
            SpeedUnit fromUnit,
            SpeedUnit toUnit,
            double fromValue)
        {
            if (fromUnit == toUnit)
                return fromValue;

            double fromFactor = factors[(int)fromUnit];
            double toFactor = factors[(int)toUnit];
            double result = fromFactor * fromValue / toFactor;
            return result;
        }
        
    }
}
