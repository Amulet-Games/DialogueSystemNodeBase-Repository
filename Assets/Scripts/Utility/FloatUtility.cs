using System;

namespace AG
{
    public class FloatUtility
    {
        /// <summary>
        /// Return true if the two float numbers are equals or approximately close to each other.
        /// </summary>
        /// <param name="a">The float number to use to compare.</param>
        /// <param name="b">The float number to compare with.</param>
        /// <param name="epsilon">The thershold that defines how much tolerances can be given between the differences of two numbers.</param>
        /// <returns>True if the two float numbers equals or approximately close to each other.</returns>
        public static bool ApproximatelyEqualEpsilon(float a, float b, float epsilon)
        {
            float floatNormal = (1 << 23) * float.Epsilon;
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
            {
                // Shortcut, handles infinities
                return true;
            }

            if (a == 0.0f || b == 0.0f || diff < floatNormal)
            {
                // a or b is zero, or both are extremely close to it.
                // relative error is less meaningful here
                return diff < (epsilon * floatNormal);
            }

            // use relative error
            return diff / Math.Min((absA + absB), float.MaxValue) < epsilon;
        }
    }
}