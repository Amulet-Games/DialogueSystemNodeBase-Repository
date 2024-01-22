namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeView : NodeViewFrameBase<DialogueNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView ContentButtonView;


        /// <summary>
        /// View for the dialogue speaker field.
        /// </summary>
        public CommonObjectFieldView<DialogueCharacter> DialogueSpeakerFieldView;


        /// <summary>
        /// View for the message modifier group.
        /// </summary>
        public MessageModifierGroupView MessageModifierGroupView;


        /// <summary>
        /// The input port of the node.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// The output port of the node.
        /// </summary>
        public Port OutputPort;


        /// <inheritdoc />
        public override DialogueNodeView Setup(LanguageHandler languageHandler)
        {
            ContentButtonView = new();
            MessageModifierGroupView = new();
            NodeTitleFieldView = new(value: StringConfig.DialogueNode_NodeTitleField_DefaultText);
            DialogueSpeakerFieldView = new(placeholderText: StringConfig.DialogueNode_DialogueSpeakerField_PlaceholderText);

            return this;
        }
    }
}