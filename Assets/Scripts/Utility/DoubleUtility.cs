using System;

namespace AG
{
    public static class DoubleUtility
    {
        /// <summary>
        /// Compares two double values and returns true if they are similar.
        /// </summary>
        /// <param name="value1">Extension double value.</param>
        /// <param name="value2">The double value to compare with.</param>
        /// <param name="epsilon">The threshold that defines how much tolerances can be given between the two values.</param>
        /// <returns>True if the two double values are similar.</returns>
        public static bool Approximate(this double value1, double value2, double epsilon)
        {
            if (value1 != value2)
            {
                return Math.Abs(value1 - value2) < epsilon;
            }

            return true;
        }
    }
}