namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeView : NodeViewFrameBase<EndNodeView>
    {
        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <inheritdoc />
        public override EndNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleTextFieldView = new(value: StringConfig.EndNode_TitleTextField_LabelText);

            return this;
        }
    }
}