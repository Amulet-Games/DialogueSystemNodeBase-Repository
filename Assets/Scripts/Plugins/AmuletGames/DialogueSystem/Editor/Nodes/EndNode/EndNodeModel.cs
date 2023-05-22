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
        /// Constructor of the end node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public EndNodeModel(EndNode node)
        {
            Node = node;
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}