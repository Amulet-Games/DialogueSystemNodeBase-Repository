namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeView : NodeViewBase
    {
        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <summary>
        /// Constructor of the start node view class.
        /// </summary>
        public StartNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.StartNode_TitleTextField_LabelText);
        }
    }
}
