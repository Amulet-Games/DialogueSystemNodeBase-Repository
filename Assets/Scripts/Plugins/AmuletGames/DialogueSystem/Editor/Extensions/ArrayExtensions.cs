using System;

namespace AG.DS
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Swap the two values in the given array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">Extension array.</param>
        /// <param name="index1">The zero-based index of the first swapping element to set for.</param>
        /// <param name="index1">The zero-based index of the second swapping element to set for.</param>
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            (array[index2], array[index1]) = (array[index1], array[index2]);
        }


        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        /// predicate, and returns the zero-based index of the first occurrence within the
        /// entire System.Array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">Extension array.</param>
        /// <param name="match">The System.Predicate`1 that defines the conditions of the element to set for.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of an element that matches the conditions
        /// defined by match, if found; otherwise, -1.
        /// </returns>
        public static int FindIndex<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindIndex(array, match);
        }


        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">Extension array.</param>
        /// <param name="value">The element to locate in array.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of value in the entire array, if found; otherwise, -1.
        /// </returns>
        public static int IndexOf<T>(this T[] array, T value)
        {
            return Array.IndexOf(array, value);
        }
    }
}