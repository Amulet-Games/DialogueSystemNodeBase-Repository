namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeView : NodeViewFrameBase<EventNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView ContentButtonView;


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
            ContentButtonView = new();
            NodeTitleFieldView = new(value: StringConfig.EventNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}
