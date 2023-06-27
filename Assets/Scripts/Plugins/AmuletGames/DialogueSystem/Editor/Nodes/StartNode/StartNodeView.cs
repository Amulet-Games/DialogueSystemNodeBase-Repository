namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeView : NodeViewFrameBase
    {
        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node view class.
        /// </summary>
        public StartNodeView()
        {
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}
