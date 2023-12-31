namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeCallback : EdgeCallbackFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override void Setup(DefaultEdge edge, DefaultEdgeView view)
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