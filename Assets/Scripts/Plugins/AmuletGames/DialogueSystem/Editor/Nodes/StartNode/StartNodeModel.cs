namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeModel : NodeModelFrameBase<StartNode>
    {
        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public StartNodeModel(StartNode node)
        {
            Node = node;
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            Node.GraphViewer.SerializeHandler.RemoveCachePort(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}
