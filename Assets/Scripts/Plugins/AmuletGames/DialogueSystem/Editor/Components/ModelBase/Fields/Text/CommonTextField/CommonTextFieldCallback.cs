using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldCallback
    {
        /// <summary>
        /// The targeting common text field model.
        /// </summary>
        CommonTextFieldModel model;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common text field callback class.
        /// </summary>
        /// <param name="field">The common text field model to set for.</param>
        public CommonTextFieldCallback(CommonTextFieldModel model)
        {
            this.model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common text field model's text field.
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
            model.TextField.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            model.TextField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            // Cache the previous value.
            previousValue = model.TextField.value;

            model.TextField.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            var field = model.TextField;

            if (field.value != model.PlaceholderText
             && field.value != previousValue)
            {
                // Push the current model's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(textContainer);

                WindowChangedEvent.Invoke();
            }

            field.ToggleEmptyStyle(model.PlaceholderText);
        }
    }
}