namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeView : NodeViewFrameBase<BooleanNodeView>
    {
        /// <summary>
        /// View for the content button.
        /// </summary>
        public ContentButtonView ContentButtonView;


        /// <summary>
        /// View for the condition modifier group.
        /// </summary>
        public ConditionModifierGroupView ConditionModifierGroupView;


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
            ContentButtonView = new();
            ConditionModifierGroupView = new();
            NodeTitleFieldView = new(value: StringConfig.BooleanNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}
