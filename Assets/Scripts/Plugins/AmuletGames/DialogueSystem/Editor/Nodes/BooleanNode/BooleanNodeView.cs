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
        /// Element that contains the condition modifiers.
        /// </summary>
        public ConditionModifierGroup ConditionModifierGroup;


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
            ContentButtonView = new();
            NodeTitleFieldView = new(value: StringConfig.BooleanNode_NodeTitleField_DefaultText);

            return this;
        }
    }
}
