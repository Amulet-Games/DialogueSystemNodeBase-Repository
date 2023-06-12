using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeCallback : NodeCallbackFrameBase
    <
        PreviewNode,
        PreviewNodeModel
    >
    {
        /// <summary>
        /// Constructor of the preview node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public PreviewNodeCallback
        (
            PreviewNode node,
            PreviewNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            base.RegisterEvents();

            RegisterNodeTitleTextFieldEvents();

            RegisterNodeTitleEditButtonClickEvent();

            RegisterLeftPortraitObjectFieldChangeEvent();

            RegisterRightPortraitObjectFieldChangeEvent();
        }


        /// <summary>
        /// Register events to the node title text field.
        /// </summary>
        void RegisterNodeTitleTextFieldEvents()
            => new NodeTitleTextFieldCallback(
                model: Model.NodeTitleTextFieldModel,
                widthBuffer: NodeConfig.PreviewNodeWidthBuffer).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: false,
                button: Model.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the left portrait object field.
        /// </summary>
        void RegisterLeftPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldCallback<Sprite>(
                model: Model.LeftPortraitObjectFieldModel,
                additionalChangeEvent: LeftPortraitObjectFieldChangeEvent).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the right portrait object field.
        /// </summary>
        void RegisterRightPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldCallback<Sprite>(
                model: Model.RightPortraitObjectFieldModel,
                additionalChangeEvent: RightPortraitObjectFieldChangeEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var fieldInput = Model.NodeTitleTextFieldModel.TextField.GetElementInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the left portrait object field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void LeftPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            Model.LeftPortraitImage.image = Model.LeftPortraitObjectFieldModel.Value.texture;
        }


        /// <summary>
        /// The event to invoke when the right portrait object field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RightPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            Model.RightPortraitImage.image = Model.RightPortraitObjectFieldModel.Value.texture;
        }
    }
}