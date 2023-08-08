namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeView : NodeViewBase
    {
        /// <summary>
        /// View for the character scriptable object object field.
        /// </summary>
        public CommonObjectFieldView<DialogueCharacter> CharacterObjectFieldView;


        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public MessageModifierGroupView DialogueNodeStitcher;


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
        /// Constructor of the dialogue node view class.
        /// </summary>
        public DialogueNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.DialogueNode_TitleTextField_LabelText);
            CharacterObjectFieldView = new("");
            DialogueNodeStitcher = new();
        }
    }
}