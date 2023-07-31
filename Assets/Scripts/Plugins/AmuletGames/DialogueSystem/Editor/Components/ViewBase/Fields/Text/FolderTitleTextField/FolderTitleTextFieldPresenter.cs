using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new folder title text field element.
        /// </summary>
        /// <param name="folderTitle">The folder title to set for.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new folder title text field element.</returns>
        public static TextField CreateElement
        (
            string folderTitle,
            string fieldUSS
        )
        {
            TextField textField;
            VisualElement fieldInput;
            VisualElement textElement;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            return textField;

            void CreateField()
            {
                textField = new();
                fieldInput = textField.GetFieldInput();
                textElement = textField.GetTextElement();
            }

            void SetFieldDetails()
            {
                textField.SetValueWithoutNotify(newValue: folderTitle);
                textField.isDelayed = true;
                textField.multiline = false;

                fieldInput.pickingMode = PickingMode.Ignore;
                textElement.pickingMode = PickingMode.Ignore;
            }

            void AddFieldToStyleClass()
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