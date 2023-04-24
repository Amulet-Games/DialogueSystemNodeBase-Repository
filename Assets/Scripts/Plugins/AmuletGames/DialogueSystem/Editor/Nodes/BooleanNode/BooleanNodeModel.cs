namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeModel : NodeModelFrameBase<BooleanNode>
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
        /// Constructor of the boolean node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public BooleanNodeModel(BooleanNode node)
        {
            Node = node;
            booleanNodeStitcher = new();
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;
            serializeHandler.RemoveCachePort(port: InputDefaultPort);
            serializeHandler.RemoveCachePort(port: TrueOutputDefaultPort);
            serializeHandler.RemoveCachePort(port: FalseOutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            TrueOutputDefaultPort.Disconnect(Node.GraphViewer);
            FalseOutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}
