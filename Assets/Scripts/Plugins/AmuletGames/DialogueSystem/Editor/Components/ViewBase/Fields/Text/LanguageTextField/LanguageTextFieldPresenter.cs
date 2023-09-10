using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldPresenter
    {
        /// <summary>
        /// Create a new language text field element.
        /// </summary>
        /// <param name="multiline">Set this to true to allow multiple lines in the text field and false if otherwise.</param>
        /// <param name="placeholderText">The placeholder text to set for the field.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <returns>A new language text field element.</returns>
        public static TextField CreateElement
        (
            bool multiline,
            string placeholderText,
            string fieldUSS
        )
        {
            TextField textField;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            return textField;

            void CreateField()
            {
                textField = new();
            }

            void SetFieldDetails()
            {
                textField.multiline = multiline;

                // Set white space style,
                // Normal means the texts will auto line break when it reaches the end of the field input element,
                // No wrap means the texts are shown in one line even when it's expanded outside of the field input element.
                textField.style.whiteSpace = multiline
                    ? WhiteSpace.Normal
                    : WhiteSpace.NoWrap;

                textField.pickingMode = PickingMode.Position;
            }

            void AddFieldToStyleClass()
            {
                var fieldInput = textField.GetFieldInput();
                var textElement = textField.GetTextElement();

                textField.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                textField.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Text_Field_Input);
                textElement.AddToClassList(StyleConfig.Text_Field_Element);
            }

            void ShowEmptyStyle()
            {
                textField.ShowEmptyStyle(placeholderText: placeholderText);
            }
        }
    }
}