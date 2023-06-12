namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public BooleanNodeStitcher booleanNodeStitcher;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The true output default port of the node.
        /// </summary>
        public DefaultPort TrueOutputDefaultPort;


        /// <summary>
        /// The false output default port of the node.
        /// </summary>
        public DefaultPort FalseOutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node model class.
        /// </summary>
        public BooleanNodeModel()
        {
            booleanNodeStitcher = new();
        }

        
        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: TrueOutputDefaultPort);
            graphViewer.Remove(port: FalseOutputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            TrueOutputDefaultPort.Disconnect(graphViewer);
            FalseOutputDefaultPort.Disconnect(graphViewer);
        }
    }
}
