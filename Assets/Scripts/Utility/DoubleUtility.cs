using System;

namespace AG
{
    public static class DoubleUtility
    {
        /// <summary>
        /// Compares the given double values and returns true if they are similar.
        /// </summary>
        /// <param name="value1">Extension double value.</param>
        /// <param name="value2">The double value to compare with.</param>
        /// <param name="epsilon">The threshold that defines how much tolerances can be given between the two values.</param>
        /// <returns>True if the two values are similar.</returns>
        public static bool Approximate(this double value1, double value2, double epsilon)
        {
            if (value1 != value2)
            {
                return Math.Abs(value1 - value2) < epsilon;
            }

            return true;
        }


        /// <summary>
        /// Compares the given double values and returns true if the first value is bigger than the second value.
        /// </summary>
        /// <param name="value1">Extension double value.</param>
        /// <param name="value2">The double value to compare with.</param>
        /// <param name="roundDigits">The number of fractional digits to which the comparing values should be rounded.</param>
        /// <returns>True if the first value is bigger than the second value.</returns>
        public static bool Bigger(this double value1, double value2, int roundDigits)
        {
            var roundedValue1 = Math.Round(value1, roundDigits, MidpointRounding.AwayFromZero);
            var roundedValue2 = Math.Round(value2, roundDigits, MidpointRounding.AwayFromZero);

            return roundedValue1 > roundedValue2;
        }


        /// <summary>
        /// Compares the given double values and returns true if the first value is smaller than the second value.
        /// </summary>
        /// <param name="value1">Extension double value.</param>
        /// <param name="value2">The double value to compare with.</param>
        /// <param name="roundDigits">The number of fractional digits to which the comparing values should be rounded.</param>
        /// <returns>True if the first value is smaller than the second value.</returns>
        public static bool Smaller(this double value1, double value2, int roundDigits)
        {
            var roundedValue1 = Math.Round(value1, roundDigits, MidpointRounding.AwayFromZero);
            var roundedValue2 = Math.Round(value2, roundDigits, MidpointRounding.AwayFromZero);

            return roundedValue1 < roundedValue2;
        }
    }
}