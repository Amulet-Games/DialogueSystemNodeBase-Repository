namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeViewFrameBase
    <
        TPort,
        TPortModel,
        TEdgeView
    >
        : EdgeViewBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
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