using UnityEngine.UIElements;

namespace AG
{
    public class DSLanguageTextFieldEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// <br>the correct language Content(string) in the Language Generics will changed at the sametime.</br>
        /// </summary>
        /// <param name="lgTextsContainer">LG texts container of which the text field is connecting to.</param>
        public static void RegisterValueChangedEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterValueChangedCallback(value =>
            {
                lgTextsContainer.Value.Find(String_LG => String_LG.LanguageType == DSLanguagesConfig.SelectedLanguage).GenericsContent = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time when the text field is selected,
        /// <br>if it's currently empty then hide the placeholder text,</br>
        /// <br>also show field is language dependent hint.</br>
        /// </summary>
        /// <param name="lgTextField">The LG text field this event is registered upon on.</param>
        public static void RegisterFieldFocusInEvent(TextField lgTextField)
        {
            lgTextField.RegisterCallback<FocusInEvent>(_ =>
            {
                DialogueEditorWindow.Instance.InputHint.ShowHint(DSStringsConfig.LanguageFieldInputHintText, lgTextField.worldBound);

                DSTextFieldUtility.HideEmptyStyle(lgTextField);  
            });
        }


        /// <summary>
        /// Each time when the text field is deselected,
        /// <br>if it's currently empty then show the placeholder text,</br>
        /// <br>also hide field is language dependent hint.</br>
        /// </summary>
        /// <param name="lgTextsContainer">LG texts container of which the text field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterCallback<FocusOutEvent>(_ =>
            {
                DialogueEditorWindow.Instance.InputHint.HideHint();

                DSTextFieldUtility.ShowEmptyStyle(lgTextsContainer);
            });
        }
    }
}