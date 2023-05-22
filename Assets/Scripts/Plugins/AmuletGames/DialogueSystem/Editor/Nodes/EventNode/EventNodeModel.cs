namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeModel : NodeModelFrameBase<EventNode>
    {
        /// <summary>
        /// Model for the event modifier model group.
        /// </summary>
        public EventModifierModelGroupModel EventModifierModelGroupModel;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public EventNodeModel(EventNode node)
        {
            Node = node;
            EventModifierModelGroupModel = new();
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputDefaultPort);
            Node.GraphViewer.Remove(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}
