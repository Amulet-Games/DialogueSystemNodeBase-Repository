namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeCallbackFrameBase
    <
        TPort,
        TPortModel
    >
        : EdgeCallbackBase, IEdgeCallback
        where TPort : PortFrameBase<TPort, TPortModel>
        where TPortModel : PortModel
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        public Edge<TPort, TPortModel> Edge;


        /// <summary>
        /// Setup for the edge callback frame base class.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <returns>The after setup edge callback frame base class.</returns>
        public abstract void Setup(Edge<TPort, TPortModel> edge);


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the edge is about to be removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPreRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// The callback to invoke when the edge is removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void OnPostRemoveByUser(GraphViewer graphViewer);
    }
}