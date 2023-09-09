namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeViewFrameBase
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : EdgeViewBase
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge: EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdge, TEdgeView>
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