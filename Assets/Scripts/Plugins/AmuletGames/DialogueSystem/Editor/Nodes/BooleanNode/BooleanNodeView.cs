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
        public PortBase InputPort;


        /// <summary>
        /// The true output port of the node.
        /// </summary>
        public PortBase TrueOutputPort;


        /// <summary>
        /// The false output port of the node.
        /// </summary>
        public PortBase FalseOutputPort;


        /// <inheritdoc />
        public override BooleanNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.BooleanNode_NodeTitleField_DefaultText);
            ConditionModifierGroupView = new();

            return this;
        }
    }
}
