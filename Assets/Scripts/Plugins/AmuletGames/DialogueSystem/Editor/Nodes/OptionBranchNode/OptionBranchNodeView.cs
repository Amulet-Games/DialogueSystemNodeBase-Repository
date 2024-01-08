namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeView : NodeViewFrameBase<OptionBranchNodeView>
    {
        /// <summary>
        /// Content button for adding conditions to the node.
        /// </summary>
        public CommonButton ContentButton;


        /// <summary>
        /// View for the branch title field.
        /// </summary>
        public LanguageTextFieldView BranchTitleFieldView;


        /// <summary>
        /// The input option port cell.
        /// </summary>
        public OptionPortCell InputOptionPortCell;


        /// <summary>
        /// The output port element.
        /// </summary>
        public PortBase OutputPort;


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
