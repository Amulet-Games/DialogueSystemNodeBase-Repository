using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common text field element.
        /// </summary>
        /// <param name="isMultiLine">Can the texts separate into multiple lines inside the text field when they too long to show in one line.</param>
        /// <param name="placeholderText">The placeholder text to set for the field.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new common text field element.</returns>
        public static TextField CreateElement
        (
            bool isMultiLine,
            string placeholderText,
            string fieldUSS
        )
        {
            TextField textField;

            CreateField();

            SetFieldDetails();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return textField;

            void CreateField()
            {
                textField = new();
            }

            void SetFieldDetails()
            {
                textField.multiline = isMultiLine;

                // Set white space style,
                // Normal means the texts will auto line break when it reaches the end of the field input element,
                // No wrap means the texts are shown in one line even when it's expanded outside of the field input element.
                textField.style.whiteSpace = isMultiLine
                    ? WhiteSpace.Normal
                    : WhiteSpace.NoWrap;

                textField.pickingMode = PickingMode.Position;
            }

            void ShowEmptyStyle()
            {
                textField.ShowEmptyStyle(placeholderText);
            }

            void AddFieldToStyleClass()
            {
                textField.AddToClassList(fieldUSS);
            }
        }
    }
}