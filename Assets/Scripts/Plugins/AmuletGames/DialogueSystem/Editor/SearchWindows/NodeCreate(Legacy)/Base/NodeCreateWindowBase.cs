using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// The node create window.
    /// </summary>
    public abstract class NodeCreateWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        protected GraphViewer GraphViewer;


        /// <summary>
        /// The property of the node create window entries.
        /// </summary>
        protected virtual List<SearchTreeEntry> NodeCreateWindowEntries { get; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// The callback to invoke when an entry in the node create window is selected.
        /// <para></para>
        /// <br>Read More:</br>
        /// <br>https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</br>
        /// </summary>
        /// 
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        /// 
        /// <returns>Returns true if succeeded, false otherwise.</returns>
        public abstract bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context);


        /// <summary>
        /// Generates data to populate the node create window.
        /// <br>This method is invoked when the SearchWindow first opens and when it is reloaded.</br>
        /// <para></para>
        /// <br>Read More:</br>
        /// <br>https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html</br>
        /// </summary>
        /// 
        /// <param name="context">Contextual data initially passed the window when first created.</param>
        /// 
        /// <returns>Returns a list of entries that can be displayed in the node create window.</returns>
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => NodeCreateWindowEntries;
    }
}