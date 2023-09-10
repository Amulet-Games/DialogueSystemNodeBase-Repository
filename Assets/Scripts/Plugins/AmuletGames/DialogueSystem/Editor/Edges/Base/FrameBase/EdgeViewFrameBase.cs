namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeViewFrameBase
    <
        TPort,
        TPortCreateDetail,
        TEdge,
        TEdgeView
    >
        : EdgeViewBase
        where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TPortCreateDetail : PortCreateDetailBase
        where TEdge: EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
    {
        /// <summary>
        /// Reference of the output port.
        /// </summary>
        public TPort Output;


        /// <summary>
        /// Reference of the input port.
        /// </summary>
        public TPort Input;


        /// <summary>
        /// Setup for the edge view frame base class.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        public abstract TEdgeView Setup(TPort output, TPort input);
    }
}