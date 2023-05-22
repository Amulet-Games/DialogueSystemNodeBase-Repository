using UnityEngine;
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
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="iconSprite">The icon to set for field, it shows up next to the its input area.</param>
        /// <returns>A new common text field element.</returns>
        public static TextField CreateElement
        (
            bool isMultiLine,
            string placeholderText,
            string fieldUSS01
        )
        {
            TextField commonTextField;

            CreateField();

            SetFieldDetails();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return commonTextField;

            void CreateField()
            {
                commonTextField = new();
            }

            void SetFieldDetails()
            {
                commonTextField.multiline = isMultiLine;

                // Set white space style,
                // Normal means the texts will auto line break when it reaches the end of the field input base,
                // NoWarp means the texts are shown in one line even when it's expanded outside of the field input base.
                commonTextField.style.whiteSpace = isMultiLine
                    ? WhiteSpace.Normal
                    : WhiteSpace.NoWrap;
            }

            void ShowEmptyStyle()
            {
                commonTextField.ShowEmptyStyle(placeholderText: placeholderText);
            }

            void AddFieldToStyleClass()
            {
                commonTextField.AddToClassList(fieldUSS01);
            }
        }
    }
}