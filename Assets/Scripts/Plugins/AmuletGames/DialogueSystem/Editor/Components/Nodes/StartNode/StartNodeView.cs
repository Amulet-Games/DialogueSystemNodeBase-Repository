namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeView : NodeViewFrameBase<StartNodeView>
    {
        /// <summary>
        /// The output port element.
        /// </summary>
        public Port OutputPort;


        /// <inheritdoc />
        public override StartNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.StartNode_NodeTitleField_DefaultText);
            
            return this;
        }
    }
}
