namespace AG.DS
{
    public abstract class EdgeFrameBase
    <
        TPort,
        TEdge,
        TEdgeView,
        TEdgeCallback
    >
        : EdgeBase
        where TPort : PortBase
        where TEdge : EdgeBase
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
        where TEdgeCallback : EdgeCallbackFrameBase<TPort, TEdge, TEdgeView, TEdgeCallback>
    {
        /// <inheritdoc />
        public override IEdgeCallback Callback
        {
            get
            {
                return m_Callback;
            }
        }


        /// <summary>
        /// Reference of the edge callback.
        /// </summary>
        protected IEdgeCallback m_Callback;
        /*
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
        */
    }
}