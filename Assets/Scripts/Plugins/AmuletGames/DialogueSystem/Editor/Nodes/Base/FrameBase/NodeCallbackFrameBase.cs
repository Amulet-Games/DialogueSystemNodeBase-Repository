namespace AG.DS
{
    public abstract class NodeCallbackFrameBase
    <
        TNode,
        TNodeView,
        TNodeObserver
    >
        : NodeCallbackBase, INodeCallback
        where TNode: NodeBase
        where TNodeView : NodeViewFrameBase
        where TNodeObserver : NodeObserverFrameBase<TNode, TNodeView>
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Reference of the node observer.
        /// </summary>
        public TNodeObserver Observer;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the node is about to be removed from the graph.
        /// </summary>
        public abstract void OnPreManualRemove();


        /// <summary>
        /// The callback to invoke when the node is removed from the graph.
        /// </summary>
        public abstract void OnPostManualRemove();


        /// <summary>
        /// The callback to invoke when the node is created from the graph.
        /// <br>Note that this is called after the node's loading is done, if loading is needed.</br>
        /// </summary>
        public abstract void OnPostCreate();
    }
}