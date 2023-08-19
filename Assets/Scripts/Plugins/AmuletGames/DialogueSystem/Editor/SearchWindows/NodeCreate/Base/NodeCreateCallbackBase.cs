using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// Holds the methods that can be called when the node create window changed its state.
    /// </summary>
    public abstract class NodeCreateCallbackBase
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        protected GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        protected DialogueSystemWindow DsWindow;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        protected LanguageHandler LanguageHandler;


        /// <summary>
        /// Reference of the node create observer.
        /// </summary>
        protected NodeCreateObserver Observer;


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// Read more:
        /// <see cref="NodeCreateWindowBase.OnSelectEntry(SearchTreeEntry, SearchWindowContext)"/>
        /// </summary>
        public abstract bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context);
    }
}