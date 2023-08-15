namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdge : EdgeFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionEdge Setup
        (
            OptionEdgeView view,
            IEdgeCallback callback
        )
        {
            // Setup references
            {
                View = view;
                Callback = callback;

                output = view.Output;
                input = view.Input;
            }

            // connect ports
            {
                output.ConnectTo(input);
            }

            // setup details
            {
                focusable = true;
            }

            // Add style class
            {
                AddToClassList(StyleConfig.Option_Edge);
                this.ShowConnectStyle();
            }

            return this;
        }
    }
}