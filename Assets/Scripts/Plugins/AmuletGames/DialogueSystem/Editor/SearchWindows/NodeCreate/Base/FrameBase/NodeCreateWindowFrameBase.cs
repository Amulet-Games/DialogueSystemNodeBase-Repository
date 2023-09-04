using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCreateWindowFrameBase<TNodeCreateCallback>
        : NodeCreateWindowBase
        where TNodeCreateCallback : NodeCreateCallbackBase
    {
        /// <summary>
        /// Reference of the node create callback.
        /// </summary>
        public TNodeCreateCallback Callback;


        /// <summary>
        /// Setup for the node create window frame base class.
        /// </summary>
        /// <param name="callback">The node create callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The after setup node create window.</returns>
        protected void Setup
        (
            TNodeCreateCallback callback,
            GraphViewer graphViewer
        )
        {
            Callback = callback;
            GraphViewer = graphViewer;
        }


        // ----------------------------- Services -----------------------------
        /// <inheritdoc />
        public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            return Callback.OnSelectEntry(searchTreeEntry, context);
        }
    }
}