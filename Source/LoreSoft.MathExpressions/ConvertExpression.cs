using System;
using System.Collections.Generic;
using LoreSoft.MathExpressions.Properties;
using LoreSoft.MathExpressions.UnitConversion;
using System.Globalization;
using LoreSoft.MathExpressions.Metadata;
using System.Reflection;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// A class representing unit convertion expressions.
    /// </summary>
    public class ConvertExpression : ExpressionBase
    {
        private static Dictionary<string, ConvertionMap> convertionCache;
        private static object cacheLock = new object();

        private ConvertionMap current;
        private string expression;

        /// <summary>The format of a convertion expression.</summary>
        public const string ExpressionFormat = "[{0}->{1}]";

        /// <summary>Initializes a new instance of the <see cref="ConvertExpression"/> class.</summary>
        /// <param name="expression">The convertion expression for this instance.</param>
        public ConvertExpression(string expression)
        {
            VerifyCache();
            if (!convertionCache.ContainsKey(expression))
                throw new ArgumentException(Resources.InvalidConvertionExpression + expression, "expression");

            this.expression = expression;
            current = convertionCache[expression];
            base.Evaluate = new MathEvaluate(Convert);
        }

        /// <summary>Gets the number of arguments this expression uses.</summary>
        /// <value>The argument count.</value>
        public override int ArgumentCount
        {
            get { return 1; }
        }

        /// <summary>Convert the numbers to the new unit.</summary>
        /// <param name="numbers">The numbers used in the convertion.</param>
        /// <returns>The result of the convertion execution.</returns>
        /// <exception cref="ArgumentNullException">When numbers is null.</exception>
        /// <exception cref="ArgumentException">When the length of numbers do not equal <see cref="ArgumentCount"/>.</exception>
        public double Convert(double[] numbers)
        {
            base.Validate(numbers);
            double fromValue = numbers[0];

            switch (current.UnitType)
            {
                case UnitType.Length:
                    return LengthConverter.Convert(
                        (LengthUnit) current.FromUnit,
                        (LengthUnit) current.ToUnit,
                        fromValue);
                case UnitType.Mass:
                    return MassConverter.Convert(
                        (MassUnit) current.FromUnit,
                        (MassUnit) current.ToUnit,
                        fromValue);
                case UnitType.Speed:
                    return SpeedConverter.Convert(
                        (SpeedUnit) current.FromUnit,
                        (SpeedUnit) current.ToUnit,
                        fromValue);
                case UnitType.Temperature:
                    return TemperatureConverter.Convert(
                        (TemperatureUnit) current.FromUnit,
                        (TemperatureUnit) current.ToUnit,
                        fromValue);
                case UnitType.Time:
                    return TimeConverter.Convert(
                        (TimeUnit) current.FromUnit,
                        (TimeUnit) current.ToUnit,
                        fromValue);
                case UnitType.Volume:
                    return VolumeConverter.Convert(
                        (VolumeUnit) current.FromUnit,
                        (VolumeUnit) current.ToUnit,
                        fromValue);
                default:
                    throw new ArgumentOutOfRangeException("numbers");
            }
        }


        ///<summary>
        /// Determines whether the specified expression name is for unit convertion.
        ///</summary>
        ///<param name="expression">The expression to check.</param>
        ///<returns><c>true</c> if the specified expression is a unit convertion; otherwise, <c>false</c>.</returns>
        public static bool IsConvertExpression(string expression)
        {
            //do basic checks before creating cache
            if (string.IsNullOrEmpty(expression))
                return false;

            if (expression[0] != '[')
                return false;

            VerifyCache();
            return convertionCache.ContainsKey(expression);
        }


        private static void VerifyCache()
        {
            if (convertionCache != null)
                return;

            lock (cacheLock)
            {
                if (convertionCache != null)
                    return;

                convertionCache = new Dictionary<string, ConvertionMap>(
                    StringComparer.OrdinalIgnoreCase);

                AddToCache<LengthUnit>(UnitType.Length);
                AddToCache<MassUnit>(UnitType.Mass);
                AddToCache<SpeedUnit>(UnitType.Speed);
                AddToCache<TemperatureUnit>(UnitType.Temperature);
                AddToCache<TimeUnit>(UnitType.Time);
                AddToCache<VolumeUnit>(UnitType.Volume);
            }
        }

        private static void AddToCache<T>(UnitType unitType) 
            where T : struct, IComparable, IFormattable, IConvertible
        {
            Type enumType = typeof(T);
            int[] a = (int[])Enum.GetValues(enumType);

            for (int x = 0; x < a.Length; x++)
            {
                MemberInfo parentInfo = GetMemberInfo(enumType, Enum.GetName(enumType, x));
                string parrentKey = AttributeReader.GetAbbreviation(parentInfo);
                
                for (int i = 0; i < a.Length; i++)
                {
                    if (x == i)
                        continue;

                    MemberInfo info = GetMemberInfo(enumType, Enum.GetName(enumType, i));

                    string key = string.Format(
                        CultureInfo.InvariantCulture,
                        ExpressionFormat,
                        parrentKey,
                        AttributeReader.GetAbbreviation(info));

                    convertionCache.Add(
                        key, new ConvertionMap(unitType, x, i));
                }
            }
        }

        private static MemberInfo GetMemberInfo(Type type, string name)
        {
            MemberInfo[] info = type.GetMember(name);
            if (info == null || info.Length == 0)
                return null;

            return info[0];
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterPriority>2</filterPriority>
        public override string ToString()
        {
            return expression;
        }

        private class ConvertionMap
        {
            public ConvertionMap(UnitType unitType, int fromUnit, int toUnit)
            {
                _unitType = unitType;
                _fromUnit = fromUnit;
                _toUnit = toUnit;
            }

            private UnitType _unitType;

            public UnitType UnitType
            {
                get { return _unitType; }
            }

            private int _fromUnit;

            public int FromUnit
            {
                get { return _fromUnit; }
            }

            private int _toUnit;

            public int ToUnit
            {
                get { return _toUnit; }
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.CurrentCulture, 
                    "{0}, [{1}->{2}]", 
                    _unitType, 
                    _fromUnit, 
                    _toUnit);
            }
        }
    }
}