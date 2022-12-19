using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the correct language value(string) will be changed at the sametime.</br>
        /// </summary>
        public static void RegisterValueChangedEvent() { }


        /// <summary>
        /// Each time when the text field is selected, if it's in empty style class then remove the field from it.
        /// <para>Also shows the language dependent input hint next to the field.</para>
        /// </summary>
        /// <param name="textField">The field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(TextField textField)
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
        /// Each time when the text field is deselected, if the field is empty, add the field to empty style class.
        /// <para>Also hides the language dependent input hint next to the field.</para>
        /// </summary>
        /// <param name="languageTextContainer">The container of which the field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(LanguageTextContainer languageTextContainer)
        {
            TextField textField = languageTextContainer.TextField;

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
                    InvokeWindowChangedEvent();
                }

                // Toggle empty style.
                TextFieldHelper.ToggleEmptyStyle(languageTextContainer);

                // Hide hint.
                InputHint.Instance.HideHint();
            });
        }
    }
}