namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node model class.
        /// </summary>
        public EndNodeModel()
        {
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
        }
    }
}