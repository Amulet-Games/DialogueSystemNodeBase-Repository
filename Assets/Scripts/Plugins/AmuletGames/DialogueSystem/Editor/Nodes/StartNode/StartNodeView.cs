namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeView : NodeViewFrameBase<StartNodeView>
    {
        /// <summary>
        /// The output port element.
        /// </summary>
        public PortBase OutputPort;


        /// <inheritdoc />
        public override StartNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.StartNode_NodeTitleField_DefaultText);
            
            return this;
        }
    }
}
