using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeView : NodeViewFrameBase<OptionRootNodeView>
    {
        /// <summary>
        /// Content button for adding output option port to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// Text field view for the root title.
        /// </summary>
        public LanguageTextFieldView RootTitleTextFieldView;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output option port of the node.
        /// </summary>
        public OptionPort OutputOptionPort;


        /// <summary>
        /// The output option port group view of the node.
        /// </summary>
        public OptionPortGroupView OutputOptionPortGroupView;


        /// <inheritdoc />
        public override OptionRootNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleTextFieldView = new(value: StringConfig.OptionRootNode_TitleTextField_LabelText);
            RootTitleTextFieldView = new(
                placeholderText: StringConfig.OptionRootNode_RootTitleTextField_PlaceholderText,
                languageHandler);
            OutputOptionPortGroupView = new(direction: Direction.Output);

            return this;
        }
    }
}
