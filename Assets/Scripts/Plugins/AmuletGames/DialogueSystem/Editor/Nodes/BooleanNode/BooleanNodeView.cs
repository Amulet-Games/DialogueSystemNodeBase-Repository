namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeView : NodeViewBase
    {
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public BooleanNodeStitcher booleanNodeStitcher;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The true output default port of the node.
        /// </summary>
        public DefaultPort TrueOutputDefaultPort;


        /// <summary>
        /// The false output default port of the node.
        /// </summary>
        public DefaultPort FalseOutputDefaultPort;


        /// <summary>
        /// Constructor of the boolean node view class.
        /// </summary>
        public BooleanNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.BooleanNode_TitleTextField_LabelText);
            booleanNodeStitcher = new();
        }
    }
}
