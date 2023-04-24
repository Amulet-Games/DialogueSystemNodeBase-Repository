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
        /// Constructor of the event node's model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public EventNodeModel(EventNode node)
        {
            Node = node;
            EventModifierModelGroupModel = new();
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;
            serializeHandler.RemoveCachePort(port: InputDefaultPort);
            serializeHandler.RemoveCachePort(port: OutputDefaultPort);
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
