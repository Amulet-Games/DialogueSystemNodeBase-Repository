namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeView : NodeViewBase
    {
        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// Constructor of the end node view class.
        /// </summary>
        public EndNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.EndNode_TitleTextField_LabelText);
        }
    }
}