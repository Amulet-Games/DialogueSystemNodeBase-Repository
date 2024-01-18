namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeView : NodeViewFrameBase<DialogueNodeView>
    {
        /// <summary>
        /// Content button for adding messages to the node.
        /// </summary>
        public CommonButton ContentButton;


        /// <summary>
        /// View for the dialogue speaker field.
        /// </summary>
        public CommonObjectFieldView<DialogueCharacter> DialogueSpeakerFieldView;


        /// <summary>
        /// Element that contains the message modifiers.
        /// </summary>
        public MessageModifierGroup MessageModifierGroup;


        /// <summary>
        /// The input port of the node.
        /// </summary>
        public PortBase InputPort;


        /// <summary>
        /// The output port of the node.
        /// </summary>
        public PortBase OutputPort;


        /// <inheritdoc />
        public override DialogueNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.DialogueNode_NodeTitleField_DefaultText);
            DialogueSpeakerFieldView = new(placeholderText: StringConfig.DialogueNode_DialogueSpeakerField_PlaceholderText);

            return this;
        }
    }
}