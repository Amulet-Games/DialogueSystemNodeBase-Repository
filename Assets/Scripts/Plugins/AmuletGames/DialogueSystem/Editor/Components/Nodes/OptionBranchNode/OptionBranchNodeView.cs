namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeView : NodeViewFrameBase<OptionBranchNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView m_ContentButtonView;


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
        public Port OutputPort;


        /// <inheritdoc />
        public override OptionBranchNodeView Setup(LanguageHandler languageHandler)
        {
            m_ContentButtonView = new();
            NodeTitleFieldView = new(value: StringConfig.OptionBranchNode_NodeTitleField_DefaultText);
            BranchTitleFieldView = new(languageHandler);

            return this;
        }
    }
}
