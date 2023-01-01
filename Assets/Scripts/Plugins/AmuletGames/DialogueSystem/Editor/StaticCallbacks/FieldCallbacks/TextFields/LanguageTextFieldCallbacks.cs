using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Register focus in actions to the given field element.
        /// </summary>
        /// <param name="textField">The field to assign the focus in actions to.</param>
        public static void RegisterFocusInEvent(TextField textField)
        {
            textField.RegisterCallback<FocusInEvent>(callback =>
            {
                InputHint.Instance.ShowHint
                (
                    hintText: StringsConfig.LanguageFieldInputHintText,
                    targetWorldBoundRect: textField.worldBound
                );

                // Hide empty style.
                TextFieldHelper.HideEmptyStyle(textField);  
            });
        }


        /// <summary>
        /// Register focus out actions to the given container's field element.
        /// </summary>
        /// <param name="languageTextContainer">The container that connects with the field that the focus out actions are assigning to.</param>
        public static void RegisterFocusOutEvent(LanguageTextContainer languageTextContainer)
        {
            var textField = languageTextContainer.TextField;

            string containerValue =
                languageTextContainer.LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage];

            textField.RegisterCallback<FocusOutEvent>(callback =>
            {
                if (textField.value != languageTextContainer.PlaceholderText
                    && textField.value != containerValue)
                {
                    // Push the current container's value to the undo stack.
                    ///TestingWindow.Instance.PushUndo(languageTextContainer);

                    // Set container's new value.
                    languageTextContainer.LanguageGeneric
                        .ValueByLanguageType[LanguagesConfig.SelectedLanguage] = textField.value;

                    // Set has unsaved changes.
                    WindowChangedEvent.Invoke();
                }

                // Toggle empty style.
                TextFieldHelper.ToggleEmptyStyle(languageTextContainer);

                // Hide hint.
                InputHint.Instance.HideHint();
            });
        }
    }
}