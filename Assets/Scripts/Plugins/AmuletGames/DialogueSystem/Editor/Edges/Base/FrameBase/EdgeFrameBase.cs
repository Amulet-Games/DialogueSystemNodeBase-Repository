namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeFrameBase
    <
        TPort,
        TPortCreateDetail,
        TEdge,
        TEdgeView
    >
        : EdgeBase
        where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TPortCreateDetail : PortCreateDetailBase
        where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
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
        public virtual TEdge Setup
        (
            TEdgeView view,
            IEdgeCallback callback
        )
        {
            View = view;
            Callback = callback;

            output = view.Output;
            input = view.Input;

            output.Connect(this);
            input.Connect(this);

            return null;
        }
    }
}