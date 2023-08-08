using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldObserver
    {
        /// <summary>
        /// The targeting language text field.
        /// </summary>
        TextField field;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        string placeholderText;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common text field observer class.
        /// </summary>
        /// <param name="view">The common text field view to set for.</param>
        public CommonTextFieldObserver
        (
            CommonTextFieldView view
        )
        {
            field = view.TextField;
            placeholderText = view.PlaceholderText;
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
        void RegisterFocusInEvent() => field.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            previousValue = field.value;

            field.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            if (field.value != placeholderText
             && field.value != previousValue)
            {
                // Push the current view's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(textContainer);

                WindowChangedEvent.Invoke();
            }

            field.ToggleEmptyStyle(placeholderText);
        }
    }
}