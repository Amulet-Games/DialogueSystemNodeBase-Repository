namespace AG.DS
{
    public abstract class EdgeModelFrameBase<TPort>
        : EdgeModelBase
        where TPort : PortBase
    {
        /// <summary>
        /// The output port of the edge.
        /// </summary>
        public TPort Output;


        /// <summary>
        /// The input port of the edge.
        /// </summary>
        public TPort Input;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        public abstract void Setup(TPort output, TPort input);
    }
}