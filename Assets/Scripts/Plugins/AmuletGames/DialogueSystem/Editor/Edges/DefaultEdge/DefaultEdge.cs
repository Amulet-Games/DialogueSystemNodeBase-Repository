namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdge : EdgeFrameBase
    <
        DefaultPort,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultEdge Setup
        (
            DefaultEdgeView view,
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
                AddToClassList(StyleConfig.Default_Edge);
            }

            return this;
        }
    }
}