namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeModel : NodeModelFrameBase<EndNode>
    {
        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public EndNodeModel(EndNode node)
        {
            Node = node;
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            Node.GraphViewer.SerializeHandler.RemoveCachePort(port: InputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}