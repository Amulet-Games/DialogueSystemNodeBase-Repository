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
        /// <typeparam name="TSearchWindow">Type search window</typeparam>
        /// <param name="searchTreeEntries">The search tree entries to set for.</param>
        /// <returns>A new search window component</returns>
        public static TSearchWindow CreateWindow<TSearchWindow>(List<SearchTreeEntry> searchTreeEntries)
            where TSearchWindow : SearchWindow
        {
            var window = ScriptableObject.CreateInstance<TSearchWindow>();
            window.SearchTreeEntries = searchTreeEntries;
            return window;
        }
    }
}