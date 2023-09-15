namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeView : NodeViewFrameBase<OptionBranchNodeView>
    {
        /// <summary>
        /// Content button for adding conditions to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// View for the branch title field.
        /// </summary>
        public LanguageTextFieldView BranchTitleFieldView;


        /// <summary>
        /// The input option port of the node.
        /// </summary>
        public OptionPort InputOptionPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override OptionBranchNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(
                value: StringConfig.OptionBranchNode_NodeTitleField_DefaultText
            );

            BranchTitleFieldView = new
            (
                placeholderText: StringConfig.OptionBranchNode_BranchTitleField_PlaceholderText,
                languageHandler
            );

            return this;
        }
    }
}
