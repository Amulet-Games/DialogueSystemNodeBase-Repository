using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class NodeCreateWindowFrameBase
    <
        TNodeCreateWindow,
        TNodeCreateCallback,
        TNodeCreateDetail
    >
        : NodeCreateWindowBase
        where TNodeCreateWindow : NodeCreateWindowFrameBase<TNodeCreateWindow, TNodeCreateCallback, TNodeCreateDetail>
        where TNodeCreateCallback : NodeCreateCallbackBase
        where TNodeCreateDetail : NodeCreateDetailBase
    {
        /// <summary>
        /// Reference of the node create callback.
        /// </summary>
        public TNodeCreateCallback Callback;


        /// <summary>
        /// Reference of the node create detail.
        /// </summary>
        public TNodeCreateDetail Detail;


        /// <summary>
        /// Setup for the node create window frame base class.
        /// </summary>
        /// <param name="callback">The node create callback to set for.</param>
        /// <param name="detail">The node create detail to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The after setup node create window.</returns>
        public virtual TNodeCreateWindow Setup
        (
            TNodeCreateCallback callback,
            TNodeCreateDetail detail,
            GraphViewer graphViewer
        )
        {
            Callback = callback;
            Detail = detail;
            GraphViewer = graphViewer;

            return null;
        }


        // ----------------------------- Services -----------------------------
        /// <inheritdoc />
        public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            return Callback.OnSelectEntry(searchTreeEntry, context);
        }
    }
}