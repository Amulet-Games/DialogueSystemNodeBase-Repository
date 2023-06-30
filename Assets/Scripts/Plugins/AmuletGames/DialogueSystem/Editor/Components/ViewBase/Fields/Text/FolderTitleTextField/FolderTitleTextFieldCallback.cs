using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldCallback
    {
        /// <summary>
        /// The targeting folder title text field.
        /// </summary>
        TextField field;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        /// <summary>
        /// The new value that was set during the ChangeEvent,
        /// <br>this new values is guarantee to be different from the field's previous value.</br>
        /// </summary>
        string newValue;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder title text field callback class.
        /// </summary>
        /// <param name="view">The folder title text field view to set for.</param>
        public FolderTitleTextFieldCallback(FolderTitleTextFieldView view)
        {
            field = view.TextField;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the folder title text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterFieldInputFocusInEvent();

            RegisterFieldInputFocusOutEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => field.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register FocusInEvent to the field input element.
        /// </summary>
        void RegisterFieldInputFocusInEvent() =>
            field.GetFieldInput().RegisterCallback<FocusInEvent>(FieldInputFocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field input element.
        /// </summary>
        void RegisterFieldInputFocusOutEvent() =>
            field.GetFieldInput().RegisterCallback<FocusOutEvent>(FieldInputFocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<string> evt)
        {
            // Since the folder title text field's isDelay value is set to true,
            // this callback will only be invoked when the user pressed Enter or Return key.

            // If the field has a new value, the value needs to be different than the previous one,
            // empty string will also be count as new value.

            newValue = evt.newValue;
        }


        /// <summary>
        /// The event to invoke when the field input element has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FieldInputFocusInEvent(FocusInEvent evt)
        {
            // Cache the previous value.
            previousValue = field.value;

            // Allow user to interact with the field input element.
            field.GetFieldInput().pickingMode = PickingMode.Position;
        }


        /// <summary>
        /// The event to invoke when the field input element has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FieldInputFocusOutEvent(FocusOutEvent evt)
        {
            if (newValue == "")
            {
                // If the new value is empty, reset it to the previous value.
                field.SetValueWithoutNotify(previousValue);
            }
            else
            {
                WindowChangedEvent.Invoke();
            }

            // Forbidden user to interact with the field input element.
            var fieldInputElement = field.GetFieldInput();
            fieldInputElement.focusable = false;
            fieldInputElement.pickingMode = PickingMode.Ignore;
        }
    }
}