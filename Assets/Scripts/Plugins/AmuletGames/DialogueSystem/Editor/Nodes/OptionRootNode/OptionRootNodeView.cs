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
        /// View for the root title field.
        /// </summary>
        public LanguageTextFieldView RootTitleFieldView;


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
            NodeTitleFieldView = new(value: StringConfig.OptionRootNode_NodeTitleField_DefaultText);

            RootTitleFieldView = new
            (
                placeholderText: StringConfig.OptionRootNode_RootTitleField_PlaceholderText,
                languageHandler
            );

            OutputOptionPortGroupView = new(direction: Direction.Output);

            return this;
        }
    }
}
