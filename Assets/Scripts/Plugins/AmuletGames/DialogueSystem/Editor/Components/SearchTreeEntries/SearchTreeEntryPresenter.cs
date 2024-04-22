using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class SearchTreeEntryPresenter
    {
        /// <summary>
        /// Create a new search tree entry.
        /// </summary>
        /// <param name="text">The text to set for.</param>
        /// <param name="icon">The icon to set for.</param>
        /// <param name="level">The level to set for.</param>
        /// <param name="userData">The user data to set for.</param>
        /// <returns>A new search tree entry.</returns>
        public static SearchTreeEntry CreateEntry
        (
            string text,
            Texture2D icon,
            int level,
            object userData
        )
        {
            return new(content: new GUIContent(text: text, image: icon))
            {
                level = level,
                userData = userData
            };
        }
    }
}