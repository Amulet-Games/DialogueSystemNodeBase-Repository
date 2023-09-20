namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeView : NodeViewFrameBase<DialogueNodeView>
    {
        /// <summary>
        /// Content button for adding messages to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// View for the dialogue speaker field.
        /// </summary>
        public CommonObjectFieldView<DialogueCharacter> DialogueSpeakerFieldView;


        /// <summary>
        /// View for the message modifier group.
        /// </summary>
        public MessageModifierGroupView MessageModifierGroupView;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override DialogueNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.DialogueNode_NodeTitleField_DefaultText);
            DialogueSpeakerFieldView = new(placeholderText: StringConfig.DialogueNode_DialogueSpeakerField_PlaceholderText);
            MessageModifierGroupView = new();

            return this;
        }
    }
}