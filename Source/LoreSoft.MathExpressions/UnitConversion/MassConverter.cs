using LoreSoft.MathExpressions.Metadata;
namespace LoreSoft.MathExpressions.UnitConversion
{
    /// <summary>Units for Mass</summary>
    public enum MassUnit
    {
        /// <summary>Milligram unit (mg)</summary>
        [Abbreviation("mg")]
        Milligram = 0,
        /// <summary>Gram unit (g)</summary>
        [Abbreviation("g")]
        Gram = 1,
        /// <summary>Kilogram unit (kg)</summary>
        [Abbreviation("kg")]
        Kilogram = 2,
        /// <summary>Ounce unit (oz)</summary>
        [Abbreviation("oz")]
        Ounce = 3,
        /// <summary>Pound unit (lb)</summary>
        [Abbreviation("lb")]
        Pound = 4,
        /// <summary>Ton unit (ton)</summary>
        [Abbreviation("ton")]
        Ton = 5,
    }

    /// <summary>
    /// Class representing mass convertion.
    /// </summary>
    public static class MassConverter
    {
        // In enum order
        private static readonly double[] factors = new double[]
            {
                0.000001d,           //milligram
                0.001d,              //gram
                1d,                  //kilogram
                0.45359237d/16d,      //ounce
                0.45359237d,         //pound
                0.45359237d*2000d,    //ton [short, US]      
            };

        /// <summary>
        /// Converts the specified from unit to the specified unit.
        /// </summary>
        /// <param name="fromUnit">Covert from unit.</param>
        /// <param name="toUnit">Covert to unit.</param>
        /// <param name="fromValue">Covert from value.</param>
        /// <returns>The converted value.</returns>
        public static double Convert(
            MassUnit fromUnit,
            MassUnit toUnit,
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
