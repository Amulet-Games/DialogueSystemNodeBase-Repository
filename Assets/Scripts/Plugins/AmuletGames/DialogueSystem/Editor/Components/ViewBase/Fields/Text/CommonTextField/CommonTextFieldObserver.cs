using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldObserver
    {
        /// <summary>
        /// The targeting common text field view.
        /// </summary>
        CommonTextFieldView view;


        /// <summary>
        /// The targeting common text field.
        /// </summary>
        TextField field;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        /// <summary>
        /// Constructor of the common text field observer class.
        /// </summary>
        /// <param name="view">The common text field view to set for.</param>
        public CommonTextFieldObserver(CommonTextFieldView view)
        {
            this.view = view;
            field = view.Field;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusInEvent();

            RegisterFocusOutEvent();

            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() => field.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        /// <summary>
        /// Register MouseDownEvent to the field.
        /// </summary>
        void RegisterMouseDownEvent() => view.Field.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            previousValue = field.value;

            if (view.Value.IsNullOrEmpty())
            {
                field.SetActivePlaceholderText(view.PlaceholderText, active: false);
            }

            field.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            view.Value = field.value;

            if (view.Value != previousValue)
            {
                // Push the current view's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(textContainer);

                WindowChangedEvent.Invoke();
            }
        }


        /// <summary>
        /// The event to invoke when the mouse button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}