namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeCallback : EdgeCallbackFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override void Setup(OptionEdge edge, OptionEdgeView view)
        {
            Edge = edge;
            View = view;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Disconnect ports
            {
                View.Input.Disconnect(Edge);
                View.Output.Disconnect(Edge);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }
    }
}