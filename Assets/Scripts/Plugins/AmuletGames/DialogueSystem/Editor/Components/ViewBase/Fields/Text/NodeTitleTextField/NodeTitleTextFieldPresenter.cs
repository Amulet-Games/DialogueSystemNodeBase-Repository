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
            VisualElement fieldInput;
            VisualElement textElement;

            CreateField();

            SetFieldDetails();

            SetupStyleClass();

            return textField;

            void CreateField()
            {
                textField = new();
                fieldInput = textField.GetFieldInput();
                textElement = textField.GetTextElement();
            }

            void SetFieldDetails()
            {
                textField.SetValueWithoutNotify(newValue: nodeTitle);
                textField.isDelayed = true;
                textField.multiline = false;

                fieldInput.pickingMode = PickingMode.Ignore;
                textElement.pickingMode = PickingMode.Ignore;
            }

            void SetupStyleClass()
            {
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