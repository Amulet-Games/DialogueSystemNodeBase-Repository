namespace AG.DS
{
    public abstract class EdgeFrameBase<TPort>
        : EdgeBase
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


        /// <summary>
        /// Setup for the edge frame base class.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        public void Setup(TPort output, TPort input)
        {
            this.output = output;
            this.input = input;

            Output = output;
            Input = input;

            Output.Connect(this);
            Input.Connect(this);
        }
    }
}