using System.Text;

namespace AG
{
    public static class StringUtility
    {
        /// <summary>
        /// Static reference of the string builder utility class.
        /// </summary>
        static StringBuilder instance;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, create a new stringBuilder class and assign it as local reference.
        /// </summary>
        public static void Setup()
        {
            instance ??= new StringBuilder();
        }


        // ----------------------------- String Utility -----------------------------
        /// <summary>
        /// Clear the internal string builder's cache and initialize it with the new given text.
        /// </summary>
        /// <param name="text01">First text to insert to the cleared string builder.</param>
        /// <returns>A string builder that contains the specificed text.</returns>
        public static StringBuilder New(string text01)
        {
            instance.Clear();
            instance.Append(text01);
            return instance;
        }


        /// <summary>
        /// Clear the internal string builder's cache and initialize it with the new given texts.
        /// </summary>
        /// <param name="text01">First text to insert to the cleared string builder.</param>
        /// <param name="text02">Second text to insert to the cleared string builder.</param>
        /// <returns>A string builder that contains the specificed texts.</returns>
        public static StringBuilder New(string text01, string text02)
        {
            instance.Clear();
            instance.Append(text01).Append(text02);
            return instance;
        }
    }
}