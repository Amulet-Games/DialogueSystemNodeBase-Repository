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
        /// The input default port element.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port element.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override EventNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.EventNode_NodeTitleField_DefaultText);
            EventModifierGroupView = new();

            return this;
        }
    }
}
