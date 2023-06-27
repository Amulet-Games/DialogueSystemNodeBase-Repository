using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldCallback
    {
        /// <summary>
        /// The targeting common text field view.
        /// </summary>
        CommonTextFieldView view;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common text field callback class.
        /// </summary>
        /// <param name="view">The common text field view to set for.</param>
        public CommonTextFieldCallback(CommonTextFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusInEvent();

            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() =>
            view.TextField.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            view.TextField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            // Cache the previous value.
            previousValue = view.TextField.value;

            view.TextField.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            var field = view.TextField;

            if (field.value != view.PlaceholderText
             && field.value != previousValue)
            {
                // Push the current view's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(textContainer);

                WindowChangedEvent.Invoke();
            }

            field.ToggleEmptyStyle(view.PlaceholderText);
        }
    }
}