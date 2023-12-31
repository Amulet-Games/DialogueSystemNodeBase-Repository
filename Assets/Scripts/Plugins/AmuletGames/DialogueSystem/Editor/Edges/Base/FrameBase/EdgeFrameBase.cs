namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeFrameBase
    <
        TPort,
        TPortModel,
        TEdge,
        TEdgeView
    >
        : EdgeBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TPortModel : PortModel
        where TEdge : EdgeFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdge, TEdgeView>
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