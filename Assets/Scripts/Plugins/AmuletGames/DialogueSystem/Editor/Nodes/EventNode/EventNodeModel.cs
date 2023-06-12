namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// Content button for adding events to the node.
        /// </summary>
        public ContentButton ContentButton;


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
        public EventNodeModel()
        {
            EventModifierModelGroupModel = new();
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}
