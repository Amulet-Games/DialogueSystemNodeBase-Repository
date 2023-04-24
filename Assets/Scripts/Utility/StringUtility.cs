using System.Text;

namespace AG.DS
{
    public static class StringUtility
    {
        /// <summary>
        /// Clear the internal string builder's cache and initialize it with the new given texts.
        /// </summary>
        /// <param name="text01">First text to insert to the cleared string builder.</param>
        /// <param name="text02">Second text to insert to the cleared string builder.</param>
        /// <returns>A string builder that contains the specificed texts.</returns>
        public static StringBuilder New(string text01, string text02)
        {
            StringBuilder sb = new(text01);
            sb.Append(text02);
            return sb;
        }
    }
}