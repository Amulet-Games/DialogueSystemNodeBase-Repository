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
        /// Constructor of the start node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public StartNodeModel(StartNode node)
        {
            Node = node;
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}
