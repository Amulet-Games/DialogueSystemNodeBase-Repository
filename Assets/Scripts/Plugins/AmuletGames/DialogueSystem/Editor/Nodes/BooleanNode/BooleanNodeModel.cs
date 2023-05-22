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
        /// Constructor of the boolean node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public BooleanNodeModel(BooleanNode node)
        {
            Node = node;
            booleanNodeStitcher = new();
        }

        
        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputDefaultPort);
            Node.GraphViewer.Remove(port: TrueOutputDefaultPort);
            Node.GraphViewer.Remove(port: FalseOutputDefaultPort);
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
