using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class SearchTreeGroupEntryPresenter
    {
        /// <summary>
        /// Create a new search tree group entry.
        /// </summary>
        /// <param name="text">The name to set for.</param>
        /// <param name="level">The level to set for.</param>
        /// <returns>A new search tree group entry.</returns>
        public static SearchTreeGroupEntry CreateEntry(string text, int level)
        {
            return new(content: new GUIContent(text: text), level: level);
        }
    }
}