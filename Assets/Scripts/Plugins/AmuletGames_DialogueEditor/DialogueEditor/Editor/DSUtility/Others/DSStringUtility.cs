using System.Text;

namespace AG
{
    public static class DSStringUtility
    {
        /// <summary>
        /// Dialogue system's string builder.
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
        /// Clear the dialogue system's string builder and initialize it with the new text 
        /// <br>that are specified.</br>
        /// </summary>
        /// <param name="Text01">First text to insert to the cleared string builder.</param>
        /// <returns>A string builder that contains the specificed text.</returns>
        public static StringBuilder New(string Text01)
        {
            instance.Clear();
            instance.Append(Text01);
            return instance;
        }


        /// <summary>
        /// Clear the dialogue system's string builder and initialize it with the new texts
        /// <br>that are specified.</br>
        /// </summary>
        /// <param name="Text01">First text to insert to the cleared string builder.</param>
        /// <param name="Text02">Second text to insert to the cleared string builder.</param>
        /// <returns>A string builder that contains the specificed texts.</returns>
        public static StringBuilder New(string Text01, string Text02)
        {
            instance.Clear();
            instance.Append(Text01).Append(Text02);
            return instance;
        }
    }
}