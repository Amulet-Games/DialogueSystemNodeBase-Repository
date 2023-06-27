using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new language text field element.
        /// </summary>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The placeholder text to set for the field.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new language text field element.</returns>
        public static TextField CreateElement
        (
            bool isMultiLine,
            string placeholderText,
            string fieldUSS
        )
        {
            TextField languageTextField;

            CreateField();

            SetFieldDetails();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return languageTextField;

            void CreateField()
            {
                languageTextField = new();
            }

            void SetFieldDetails()
            {
                languageTextField.multiline = isMultiLine;

                // Set white space style,
                // Normal means the texts will auto line break when it reaches the end of the field input base,
                // NoWarp means the texts are shown in one line even when it's expanded outside of the field input base.
                languageTextField.style.whiteSpace = isMultiLine
                    ? WhiteSpace.Normal
                    : WhiteSpace.NoWrap;
            }

            void ShowEmptyStyle()
            {
                languageTextField.ShowEmptyStyle(placeholderText: placeholderText);
            }

            void AddFieldToStyleClass()
            {
                languageTextField.AddToClassList(fieldUSS);
            }
        }
    }
}