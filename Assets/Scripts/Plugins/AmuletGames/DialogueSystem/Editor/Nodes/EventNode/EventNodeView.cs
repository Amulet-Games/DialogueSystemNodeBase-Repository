namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeView : NodeViewFrameBase<EventNodeView>
    {
        /// <summary>
        /// Content button for adding events to the node.
        /// </summary>
        public CommonButton ContentButton;


        /// <summary>
        /// View for the event modifier group.
        /// </summary>
        public EventModifierGroupView EventModifierGroupView;


        /// <summary>
        /// The input port element.
        /// </summary>
        public PortBase InputPort;


        /// <summary>
        /// The output port element.
        /// </summary>
        public PortBase OutputPort;


        /// <inheritdoc />
        public override EventNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.EventNode_NodeTitleField_DefaultText);
            EventModifierGroupView = new();

            return this;
        }
    }
}
