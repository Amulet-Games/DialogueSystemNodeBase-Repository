namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeView : NodeViewBase
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


        /// <summary>
        /// Constructor of the event node view class.
        /// </summary>
        public EventNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.EventNode_TitleTextField_LabelText);
            EventModifierGroupView = new();
        }
    }
}
