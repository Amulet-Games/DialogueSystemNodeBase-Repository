using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeObserver : NodeObserverFrameBase
    <
        PreviewNode,
        PreviewNodeView
    >
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(PreviewNode node)
        {
            base.RegisterEvents(node);
            
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();

            RegisterNodeTitleTextFieldEvents();

            RegisterNodeTitleEditButtonClickEvent();

            RegisterLeftPortraitObjectFieldChangeEvent();

            RegisterRightPortraitObjectFieldChangeEvent();

            RegisterAdditionLeftPortraitFieldChangeEvent();

            RegisterAdditionRightPortraitFieldChangeEvent();
        }


        /// <summary>
        /// Register events to the node title text field.
        /// </summary>
        void RegisterNodeTitleTextFieldEvents()
            => new NodeTitleTextFieldObserver(
                view: View.NodeTitleFieldView).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: false,
                button: View.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the left portrait field.
        /// </summary>
        void RegisterLeftPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldObserver<Sprite>(
                view: View.LeftPortraitObjectFieldView).RegisterEvents();


        /// <summary>
        /// Register ChangeEvent to the right portrait field.
        /// </summary>
        void RegisterRightPortraitObjectFieldChangeEvent()
            => new CommonObjectFieldObserver<Sprite>(
                view: View.RightPortraitObjectFieldView).RegisterEvents();


        /// <summary>
        /// Register additional ChangeEvent to the left portrait field.
        /// </summary>
        void RegisterAdditionLeftPortraitFieldChangeEvent()
            => View.LeftPortraitObjectFieldView.Field
                .RegisterValueChangedCallback(AdditionalLeftPortraitFieldChangeEvent);


        /// <summary>
        /// Register additional ChangeEvent to the right portrait field.
        /// </summary>
        void RegisterAdditionRightPortraitFieldChangeEvent()
            => View.RightPortraitObjectFieldView.Field
                .RegisterValueChangedCallback(AdditionalRightPortraitFieldChangeEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        void NodeTitleEditButtonClickEvent()
        {
            var fieldInput = View.NodeTitleFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the left portrait field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void AdditionalLeftPortraitFieldChangeEvent(ChangeEvent<Object> evt)
        {
            View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
        }


        /// <summary>
        /// The event to invoke when the right portrait field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void AdditionalRightPortraitFieldChangeEvent(ChangeEvent<Object> evt)
        {
            View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
        }
    }
}