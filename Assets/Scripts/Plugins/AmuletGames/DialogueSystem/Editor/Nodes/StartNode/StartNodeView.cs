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
            NodeTitleTextFieldView = new(value: StringConfig.StartNode_TitleTextField_LabelText);
            
            return this;
        }
    }
}
