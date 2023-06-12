namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node model class.
        /// </summary>
        public StartNodeModel()
        {
        }


        // ----------------------------- Remove Ports All -----------------------------
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
