namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeView : NodeViewFrameBase<BooleanNodeView>
    {
        /// <summary>
        /// Content button for adding conditions to the node.
        /// </summary>
        public CommonButton ContentButton;


        /// <summary>
        /// View for the condition modifier group.
        /// </summary>
        public ConditionModifierGroupView ConditionModifierGroupView;


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
            ConditionModifierGroupView = new();

            return this;
        }
    }
}
