using System.Text;
using UnityEngine;

namespace AG
{
    public static class DSStringBuilder
    {
        [Header("String Builder.")]
        private static StringBuilder strBuilder;

        #region Setup.
        public static void Setup()
        {
            if (strBuilder == null)
                strBuilder = new StringBuilder();
        }
        #endregion

        public static StringBuilder AppendNew(string startingText)
        {
            strBuilder.Clear();
            strBuilder.Append(startingText);
            return strBuilder;
        }
    }
}