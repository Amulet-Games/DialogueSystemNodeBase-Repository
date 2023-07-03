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
                var field_input = textField.GetFieldInput();
                var text_element = textField.GetTextElement();

                textField.ClearClassList();
                field_input.ClearClassList();
                text_element.ClearClassList();

                textField.AddToClassList(fieldUSS);
                field_input.AddToClassList(StyleConfig.TextField_Input);
                text_element.AddToClassList(StyleConfig.TextField_Element);
            }
        }
    }
}