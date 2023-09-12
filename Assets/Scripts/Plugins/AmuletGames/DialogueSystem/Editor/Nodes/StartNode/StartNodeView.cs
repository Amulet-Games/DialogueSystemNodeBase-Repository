namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeView : NodeViewFrameBase<StartNodeView>
    {
        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override StartNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.StartNode_NodeTitleField_DefaultText);
            
            return this;
        }
    }
}
