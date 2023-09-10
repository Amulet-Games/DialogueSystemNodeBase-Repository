using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonTextFieldPresenter
    {
        /// <summary>
        /// Create a new common text field element.
        /// </summary>
        /// <param name="multiline">Set this to true to allow multiple lines in the text field and false if otherwise.</param>
        /// <param name="placeholderText">The field placeholder text to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <returns>A new common text field element.</returns>
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

            ShowEmptyStyle();

            AddFieldToStyleClass();

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