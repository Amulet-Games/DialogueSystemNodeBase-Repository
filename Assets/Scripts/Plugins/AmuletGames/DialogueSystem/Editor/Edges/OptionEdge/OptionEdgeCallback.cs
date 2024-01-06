namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeCallback : EdgeCallbackFrameBase
    <
        OptionPort,
        OptionPortModel
    >
    {
        /// <inheritdoc />
        public override void Setup(Edge<OptionPort, OptionPortModel> edge)
        {
            Edge = edge;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Disconnect ports
            {
                Edge.Input.Disconnect(Edge);
                Edge.Output.Disconnect(Edge);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }
    }
}