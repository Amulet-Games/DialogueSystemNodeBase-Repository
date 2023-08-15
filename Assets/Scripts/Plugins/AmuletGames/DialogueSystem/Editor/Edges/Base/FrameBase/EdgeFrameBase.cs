namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeFrameBase
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : EdgeBase
        where TPort : PortBase
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
    {
        /// <summary>
        /// Reference of the edge view;
        /// </summary>
        public TEdgeView View;


        /// <summary>
        /// Setup for the edge frame base class.
        /// </summary>
        /// <param name="view">The edge view to set for.</param>
        /// <param name="callback">The edge callback to set for.</param>
        public abstract TEdge Setup
        (
            TEdgeView view,
            IEdgeCallback callback
        );
    }
}