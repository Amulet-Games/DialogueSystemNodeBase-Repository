using UnityEngine.UIElements;

namespace AG
{
    public class DSLanguageTextFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the correct language Content(string) in the Language Generics will changed at the sametime.</br>
        /// </summary>
        /// <param name="lgTextsContainer">The LG texts container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterValueChangedCallback(value =>
            {
                lgTextsContainer.Value
                    .Find(String_LG => String_LG.LanguageType == DSLanguagesConfig.SelectedLanguage)
                    .GenericsContent = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time when the text field is selected, if it's in empty style class then remove the field from it.
        /// <para>Also shows the language dependent input hint next to the field.</para>
        /// </summary>
        /// <param name="lgTextField">The LG text field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(TextField lgTextField)
        {
            lgTextField.RegisterCallback<FocusInEvent>(_ =>
            {
                DialogueEditorWindow.Instance.InputHint.ShowHint
                (
                    DSStringsConfig.LanguageFieldInputHintText,
                    lgTextField.worldBound
                );

                // When input field was clicked and it's empty,
                // remove the previous added empty style class.
                DSTextFieldUtility.HideEmptyStyle(lgTextField);  
            });
        }


        /// <summary>
        /// Each time when the text field is deselected, if the field is empty, add the field to empty style class.
        /// <para>Also hides the language dependent input hint next to the field.</para>
        /// </summary>
        /// <param name="lgTextsContainer">The LG texts container of which the field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterCallback<FocusOutEvent>(_ =>
            {
                DialogueEditorWindow.Instance.InputHint.HideHint();

                // When input field was deselected and the field is empty,
                // add the field to empty style class.
                DSTextFieldUtility.ToggleEmptyStyle(lgTextsContainer);
            });
        }
    }
}