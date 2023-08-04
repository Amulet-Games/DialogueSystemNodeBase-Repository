namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeView : NodeViewFrameBase
    {
        /// <summary>
        /// Content button for adding events to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// View for the event modifier group.
        /// </summary>
        public EventModifierGroupView EventModifierGroupView;


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
        /// Constructor of the event node view class.
        /// </summary>
        public EventNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.EventNode_TitleTextField_LabelText);
            EventModifierGroupView = new();
        }


        // ----------------------------- Service -----------------------------
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
