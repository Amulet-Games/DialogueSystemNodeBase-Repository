using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeView : NodeViewFrameBase<PreviewNodeView>
    {
        /// <summary>
        /// Object field view for the left side portrait image.
        /// </summary>
        public CommonObjectFieldView<Sprite> LeftPortraitObjectFieldView;


        /// <summary>
        /// Object field view for the right side portrait image.
        /// </summary>
        public CommonObjectFieldView<Sprite> RightPortraitObjectFieldView;


        /// <summary>
        /// Image element for the left side portrait image.
        /// </summary>
        public Image LeftPortraitImage;


        /// <summary>
        /// Image element for the right side portrait image.
        /// </summary>
        public Image RightPortraitImage;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override PreviewNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleTextFieldView = new(value: StringConfig.PreviewNode_TitleTextField_LabelText);
            LeftPortraitObjectFieldView = new("");
            RightPortraitObjectFieldView = new("");

            return this;
        }
    }
}