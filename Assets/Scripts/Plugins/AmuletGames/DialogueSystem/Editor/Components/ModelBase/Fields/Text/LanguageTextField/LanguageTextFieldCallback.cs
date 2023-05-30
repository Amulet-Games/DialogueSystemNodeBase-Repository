using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldCallback
    {
        /// <summary>
        /// The targeting language text field model.
        /// </summary>
        LanguageTextFieldModel model;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language text field callback class.
        /// </summary>
        /// <param name="model">The language text field model to set for.</param>
        public LanguageTextFieldCallback(LanguageTextFieldModel model)
        {
            this.model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the language text field.
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
            var field = model.TextField;

            InputHint.ShowHint
            (
                hintText: StringConfig.InputHint_HintTextLabel_LabelText,
                targetWorldBoundRect: field.worldBound
            );

            previousValue = field.value;

            field.HideEmptyStyle();
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
                // Push the current container's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(languageTextContainer);

                model.LanguageGeneric
                    .ValueByLanguageType[LanguageManager.Instance.SelectedLanguage] = field.value;

                WindowChangedEvent.Invoke();
            }

            field.ToggleEmptyStyle(placeholderText: model.PlaceholderText);

            InputHint.HideHint();
        }
    }
}