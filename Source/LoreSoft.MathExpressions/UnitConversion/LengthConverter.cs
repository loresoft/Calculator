using LoreSoft.MathExpressions.Metadata;

namespace LoreSoft.MathExpressions.UnitConversion
{
    /// <summary>Units for Length</summary>
    public enum LengthUnit
    {
        /// <summary>Millimeter unit (mm)</summary>
        [Abbreviation("mm")]
        Millimeter = 0,
        /// <summary>Centimeter unit (cm)</summary>
        [Abbreviation("cm")]
        Centimeter = 1,
        /// <summary>Meter unit (m)</summary>
        [Abbreviation("m")]
        Meter = 2,
        /// <summary>Kilometer unit (km)</summary>
        [Abbreviation("km")]
        Kilometer = 3,
        /// <summary>Inch unit (in)</summary>
        [Abbreviation("in")]
        Inch = 4,
        /// <summary>Feet unit (ft)</summary>
        [Abbreviation("ft")]
        Feet = 5,
        /// <summary>Yard unit (yd)</summary>
        [Abbreviation("yd")]
        Yard = 6,
        /// <summary>Mile unit (mile)</summary>
        [Abbreviation("mile")]
        Mile = 7
    }

    /// <summary>
    /// Class representing length convertion.
    /// </summary>
    public static class LengthConverter
    {
        // In enum order
        private static readonly double[] factors = new double[]
            {
                0.001d,          //millimeter
                0.01d,           //centimeter
                1d,              //meter
                1000d,           //kilometer
                0.3048d/12d,      //inch
                0.3048d,         //feet
                0.9144d,         //yard
                0.3048d*5280d,    //mile
            };


        /// <summary>
        /// Converts the specified from unit to the specified unit.
        /// </summary>
        /// <param name="fromUnit">Covert from unit.</param>
        /// <param name="toUnit">Covert to unit.</param>
        /// <param name="fromValue">Covert from value.</param>
        /// <returns>The converted value.</returns>
        public static double Convert(
            LengthUnit fromUnit,
            LengthUnit toUnit,
            double fromValue)
        {
            if (fromUnit == toUnit)
                return fromValue; 
            
            double fromFactor = factors[(int)fromUnit];
            double toFactor = factors[(int) toUnit];
            double result = fromFactor * fromValue / toFactor;
            return result;
        }

    }
}
