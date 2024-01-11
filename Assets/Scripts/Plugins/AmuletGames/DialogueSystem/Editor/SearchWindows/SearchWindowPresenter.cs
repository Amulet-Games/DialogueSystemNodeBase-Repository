using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class SearchWindowPresenter
    {
        /// <summary>
        /// Create a new search window component.
        /// </summary>
        /// <param name="searchTreeEntries">The search tree entries to set for.</param>
        /// <returns>A new search window component</returns>
        public static SearchWindowBase CreateWindow(List<SearchTreeEntry> searchTreeEntries)
        {
            var window = ScriptableObject.CreateInstance<SearchWindowBase>();
            window.SearchTreeEntries = searchTreeEntries;
            return window;
        }
    }
}