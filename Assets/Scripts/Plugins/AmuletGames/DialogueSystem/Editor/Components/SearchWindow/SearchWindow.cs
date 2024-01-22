using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// The search window component.
    /// </summary>
    public class SearchWindow : ScriptableObject, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the search tree entries.
        /// </summary>
        public List<SearchTreeEntry> SearchTreeEntries;


        /// <summary>
        /// The event to invoke when an entry in the search window is selected.
        /// </summary>
        public Func<SearchTreeEntry, SearchWindowContext, bool> EntrySelectedEvent;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Generates data to populate the search window.
        /// <br>This method is invoked when the SearchWindow first opens and when it is reloaded</br>
        /// <para></para>
        /// <br>Read More:</br>
        /// <br>https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html</br>
        /// </summary>
        /// <param name="context">Contextual data initially passed the window when first created.</param>
        /// <returns>Returns the list of SearchTreeEntry objects displayed in the search window.</returns>
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => SearchTreeEntries;


        /// <summary>
        /// The method to invoke when an entry in the search window is selected.
        /// <para></para>
        /// <br>Read More:</br>
        /// <br>https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</br>
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        /// <returns>Returns true if succeeded, false otherwise.</returns>
        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
            => EntrySelectedEvent.Invoke(searchTreeEntry, context);


        /// <summary>
        /// Open the search window.
        /// </summary>
        /// <param name="openScreenPosition">The open screen position to set for.</param>
        public void OpenWindow(Vector2 openScreenPosition)
            => UnityEditor.Experimental.GraphView.SearchWindow.Open
            (
                context: new SearchWindowContext(openScreenPosition),
                provider: this
            );
    }
}