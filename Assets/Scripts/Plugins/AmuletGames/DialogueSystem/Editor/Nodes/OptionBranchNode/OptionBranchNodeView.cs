namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeView : NodeViewBase
    {
        /// <summary>
        /// Content button for adding conditions to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// Text field view for the branch title.
        /// </summary>
        public LanguageTextFieldView BranchTitleTextFieldView;


        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public OptionBranchNodeStitcher OptionBranchNodeStitcher;


        /// <summary>
        /// The input option port of the node.
        /// </summary>
        public OptionPort InputOptionPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node view class.
        /// </summary>
        public OptionBranchNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.OptionBranchNode_TitleTextField_LabelText);
            BranchTitleTextFieldView = new(placeholderText: StringConfig.OptionBranchNode_BranchTitleTextField_PlaceholderText);
            OptionBranchNodeStitcher = new();
        }
    }
}
