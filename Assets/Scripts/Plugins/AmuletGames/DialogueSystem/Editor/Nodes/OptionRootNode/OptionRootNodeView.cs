namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeView : NodeViewFrameBase<OptionRootNodeView>
    {
        /// <summary>
        /// Content button for adding output option port to the node.
        /// </summary>
        public CommonButton ContentButton;


        /// <summary>
        /// View for the root title field.
        /// </summary>
        public LanguageTextFieldView RootTitleFieldView;


        /// <summary>
        /// The input port element.
        /// </summary>
        public PortBase InputPort;


        /// <summary>
        /// The output option port group element.
        /// </summary>
        public OptionPortGroup OutputOptionPortGroup;


        /// <inheritdoc />
        public override OptionRootNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(
                value: StringConfig.OptionRootNode_NodeTitleField_DefaultText
            );

            RootTitleFieldView = new
            (
                placeholderText: StringConfig.OptionRootNode_RootTitleField_PlaceholderText,
                languageHandler
            );

            return this;
        }
    }
}
