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
        /// Element that contains the event modifiers.
        /// </summary>
        public EventModifierGroup EventModifierGroup;


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
