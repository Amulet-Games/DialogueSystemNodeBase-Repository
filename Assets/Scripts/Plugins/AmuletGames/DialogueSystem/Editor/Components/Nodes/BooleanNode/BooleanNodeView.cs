namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeView : NodeViewFrameBase<BooleanNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView m_ContentButtonView;


        /// <summary>
        /// View for the condition modifier view group.
        /// </summary>
        public ConditionModifierViewGroupView ConditionModifierViewGroupView;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// The true output port of the node.
        /// </summary>
        public Port TrueOutputPort;


        /// <summary>
        /// The false output port of the node.
        /// </summary>
        public Port FalseOutputPort;


        /// <inheritdoc />
        public override BooleanNodeView Setup(LanguageHandler languageHandler)
        {
            m_ContentButtonView = new();
            ConditionModifierViewGroupView = new();
            NodeTitleFieldView = new(value: StringConfig.BooleanNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}
