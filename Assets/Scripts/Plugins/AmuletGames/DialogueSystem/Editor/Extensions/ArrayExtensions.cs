namespace AG.DS
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Swap the two values in the given array.
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="array">Extension array.</param>
        /// <param name="index1">The array index of the first value to set for.</param>
        /// <param name="index2">The array index of the second value to set for.</param>
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}