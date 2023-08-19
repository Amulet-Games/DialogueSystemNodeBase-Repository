using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeCallbackFrameBase
    <
        TNode,
        TNodeView,
        TNodeCallback
    >
        : NodeCallbackBase, INodeCallback
        where TNode: NodeBase
        where TNodeView : NodeViewFrameBase<TNodeView>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView, TNodeCallback>
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Setup for the node callback frame base class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <returns>The after setup node callback frame base class.</returns>
        public abstract TNodeCallback Setup(TNodeView view);


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the node is about to be removed from the graph.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the node is removed from the graph.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPostManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the node is created from the graph.
        /// Note that this is called after the previous node's data is loaded.
        /// </summary>
        public abstract void OnPostCreate();
    }
}