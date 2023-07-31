using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new graph title text field element.
        /// </summary>
        /// <param name="titleText">The title text to set for.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new graph title text field element.</returns>
        public static TextField CreateElement
        (
            string titleText,
            string fieldUSS
        )
        {
            TextField textField;

            CreateField();

            SetFieldDetails();

            SetupStyleClass();

            return textField;

            void CreateField()
            {
                textField = new();
            }

            void SetFieldDetails()
            {
                textField.SetValueWithoutNotify(titleText);
                textField.isDelayed = true;
            }

            void SetupStyleClass()
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
        }
    }
}