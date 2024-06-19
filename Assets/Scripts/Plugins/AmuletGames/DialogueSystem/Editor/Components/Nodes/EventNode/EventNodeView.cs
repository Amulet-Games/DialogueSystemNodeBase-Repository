namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeView : NodeViewFrameBase<EventNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView m_ContentButtonView;


        /// <summary>
        /// View for the event modifier group.
        /// </summary>
        public EventModifierViewGroupView EventModifierGroupView;


        /// <summary>
        /// The input port element.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// The output port element.
        /// </summary>
        public Port OutputPort;


        /// <inheritdoc />
        public override EventNodeView Setup(LanguageHandler languageHandler)
        {
            m_ContentButtonView = new();
            EventModifierGroupView = new();
            NodeTitleFieldView = new(value: StringConfig.EventNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}
