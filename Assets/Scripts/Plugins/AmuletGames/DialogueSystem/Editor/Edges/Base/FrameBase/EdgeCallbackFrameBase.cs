namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeCallbackFrameBase
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : EdgeCallbackBase, IEdgeCallback
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdge, TEdgeView>
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        public TEdge Edge;


        /// <summary>
        /// Reference of the edge view.
        /// </summary>
        public TEdgeView View;


        /// <summary>
        /// Setup for the edge callback frame base class.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="view">The edge view to set for.</param>
        /// <returns>The after setup edge callback frame base class.</returns>
        public abstract void Setup(TEdge edge, TEdgeView view);


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the edge is about to be removed from the graph.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the edge is removed from the graph.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPostManualRemove(GraphViewer graphViewer);
    }
}