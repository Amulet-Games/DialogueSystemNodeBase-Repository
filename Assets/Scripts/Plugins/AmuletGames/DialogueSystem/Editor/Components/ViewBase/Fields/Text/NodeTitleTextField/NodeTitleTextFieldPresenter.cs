using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new node title text field element.
        /// </summary>
        /// <param name="nodeTitle">The node title to set for.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new node title text field element.</returns>
        public static TextField CreateElement
        (
            string nodeTitle,
            string fieldUSS
        )
        {
            TextField textField;
            VisualElement field_input;
            VisualElement text_element;

            CreateField();

            SetFieldDetails();

            SetupStyleClass();

            return textField;

            void CreateField()
            {
                textField = new();
                field_input = textField.GetFieldInput();
                text_element = textField.GetTextElement();
            }

            void SetFieldDetails()
            {
                textField.SetValueWithoutNotify(newValue: nodeTitle);
                textField.isDelayed = true;
                textField.multiline = false;

                field_input.pickingMode = PickingMode.Ignore;
                text_element.pickingMode = PickingMode.Ignore;
            }

            void SetupStyleClass()
            {
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