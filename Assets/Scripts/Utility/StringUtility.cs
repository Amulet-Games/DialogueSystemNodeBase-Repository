using System;
using System.Text;

namespace AG.DS
{
    public static class StringUtility
    {
        /// <summary>
        /// Create a new string by combining the two given string values.
        /// </summary>
        /// 
        /// <param name="str">Extension string value.</param>
        /// <param name="value">The combining value to set for.</param>
        /// 
        /// <returns>A new string that made of the two given string values combined.</returns>
        public static string Append(this string str, string value)
        {
            StringBuilder sb = new(str);
            sb.Append(value);
            return sb.ToString();
        }


        /// <summary>
        /// Create a new string by retrieving the characters from the end of the given string value and the given length.
        /// </summary>
        /// 
        /// <param name="str">Extension string value.</param>
        /// <param name="length">The length to set for.</param>
        /// 
        /// <returns>A new string that made of the end of the given string value in a given length.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given string value is null or the given length is less than 0.
        /// </exception>
        public static string Right(this string str, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("'length' has to be bigger than zero.");
            }
            if (str == null)
            {
                throw new ArgumentException("'text' can not be null.");
            }
            if (str.Length <= length)
            {
                return str;
            }
            return str.Substring(str.Length - length, length);
        }


        /// <summary>
        /// Returns true if the given value is null or empty.
        /// </summary>
        /// <param name="str">Extension string value.</param>
        /// <returns>True if the given value is null or empty./returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);


        /// <summary>
        /// Returns true if the given value matches the comparing value.
        /// </summary>
        /// 
        /// <param name="str">Extension string value.</param>
        /// <param name="value">The comparing value.</param>
        /// 
        /// <returns>True if the given value matches the comparing value.</returns>
        public static bool Match(this string str, string value) => str == value;
    }
}