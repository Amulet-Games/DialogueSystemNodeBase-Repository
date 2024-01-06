namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeView : NodeViewFrameBase<EndNodeView>
    {
        /// <summary>
        /// The input default port element.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <inheritdoc />
        public override EndNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.EndNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}