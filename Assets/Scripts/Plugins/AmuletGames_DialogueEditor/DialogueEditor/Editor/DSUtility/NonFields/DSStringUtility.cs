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
        /// Borrow the dialogue system's string builder and initialize it with the new text 
        /// <br>that are specified.</br>
        /// </summary>
        /// <param name="beginningText">The text to start off in the cleared string builder.</param>
        /// <returns>A cleared string builder that now only contains the specificed beginning text.</returns>
        public static StringBuilder New(string beginningText)
        {
            instance.Clear();
            instance.Append(beginningText);
            return instance;
        }
    }
}