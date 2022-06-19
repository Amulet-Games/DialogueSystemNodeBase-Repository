using UnityEngine.UIElements;

namespace AG
{
    public class DSLanguageTextFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the text field is assigned to a new value,
        /// the correct language Content(string) in the Language Generics will changed at the sametime.
        /// </summary>
        /// <param name="lgTextsContainer">LG texts container of which the text field is connecting to.</param>
        public static void RegisterValueChangedEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterValueChangedCallback(value =>
            {
                lgTextsContainer.Value.Find(String_LG => String_LG.languageType == SupportLanguage.selectedLanguage).genericsContent = value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }

        /// <summary>
        /// Each time when the text field is selected,
        /// if it's currently empty then hide the placeholder text,
        /// also show field is language dependent hint.
        /// </summary>
        /// <param name="lgTextField">The LG text field this event is registered upon on.</param>
        public static void RegisterFieldFocusInEvent(TextField lgTextField)
        {
            lgTextField.RegisterCallback<FocusInEvent>(_ =>
            {
                DialogueEditorWindow.dsWindow.graphView.inputHint.ShowHint(DSStringsConfig.LG_InputHintText, lgTextField.worldBound);

                DSTextFieldUtility.HideEmptyStyle(lgTextField);  
            });
        }

        /// <summary>
        /// Each time when the text field is deselected,
        /// if it's currently empty then show the placeholder text,
        /// also hide field is language dependent hint.
        /// </summary>
        /// <param name="lgTextsContainer">LG texts container of which the text field is connecting to.</param>
        public static void RegisterFieldFocusOutEvent(LanguageTextContainer lgTextsContainer)
        {
            lgTextsContainer.TextField.RegisterCallback<FocusOutEvent>(_ =>
            {
                DialogueEditorWindow.dsWindow.graphView.inputHint.HideHint();

                DSTextFieldUtility.ShowEmptyStyle(lgTextsContainer);
            });
        }
    }
}