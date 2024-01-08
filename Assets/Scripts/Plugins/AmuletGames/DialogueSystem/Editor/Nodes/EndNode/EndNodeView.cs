namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeView : NodeViewFrameBase<EndNodeView>
    {
        /// <summary>
        /// The input port element.
        /// </summary>
        public PortBase InputPort;


        /// <inheritdoc />
        public override EndNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.EndNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}