namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeView : NodeViewFrameBase<BooleanNodeView>
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


        /// <inheritdoc />
        public override BooleanNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.BooleanNode_NodeTitleField_DefaultText);
            booleanNodeStitcher = new();

            return this;
        }
    }
}
