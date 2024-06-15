namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeView : NodeViewFrameBase<OptionRootNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView m_ContentButtonView;


        /// <summary>
        /// View for the root title field.
        /// </summary>
        public LanguageTextFieldView RootTitleFieldView;


        /// <summary>
        /// The input port element.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// The output option port group element.
        /// </summary>
        public OptionPortGroup OutputOptionPortGroup;


        /// <inheritdoc />
        public override OptionRootNodeView Setup(LanguageHandler languageHandler)
        {
            m_ContentButtonView = new();
            NodeTitleFieldView = new(value: StringConfig.OptionRootNode_NodeTitleField_DefaultText);
            RootTitleFieldView = new(languageHandler);

            return this;
        }
    }
}
