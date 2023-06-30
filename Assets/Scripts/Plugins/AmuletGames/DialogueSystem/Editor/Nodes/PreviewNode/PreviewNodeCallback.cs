using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeCallback : NodeCallbackFrameBase
    <
        PreviewNode,
        PreviewNodeView
    >
    {
        /// <summary>
        /// Constructor of the preview node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public PreviewNodeCallback
        (
            PreviewNode node,
            PreviewNodeView view
        )
        {
            Node = node;
            View = view;
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
                view: View.NodeTitleTextFieldView,
                widthBuffer: NodeConfig.PreviewNodeWidthBuffer).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: false,
                button: View.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the left portrait object field.
        /// </summary>
        void RegisterLeftPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldCallback<Sprite>(
                view: View.LeftPortraitObjectFieldView,
                additionalChangeEvent: LeftPortraitObjectFieldChangeEvent).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the right portrait object field.
        /// </summary>
        void RegisterRightPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldCallback<Sprite>(
                view: View.RightPortraitObjectFieldView,
                additionalChangeEvent: RightPortraitObjectFieldChangeEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var fieldInput = View.NodeTitleTextFieldView.TextField.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the left portrait object field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void LeftPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
        }


        /// <summary>
        /// The event to invoke when the right portrait object field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RightPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
        }
    }
}