using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldPresenter
    {
        /// <summary>
        /// Create a new folder title text field element.
        /// </summary>
        /// <param name="view">The folder title text field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        public static void CreateElement
        (
            FolderTitleTextFieldView view,
            string fieldUSS
        )
        {
            TextField field;
            VisualElement fieldInput;
            VisualElement textElement;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            ShowDefaultTitle();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
                fieldInput = field.GetFieldInput();
                textElement = field.GetTextElement();
            }

            void SetFieldDetails()
            {
                field.isDelayed = true;
                field.multiline = false;
                field.maxLength = NumberConfig.MAX_CHAR_LENGTH_FOLDER_TITLE_TEXT;

                fieldInput.pickingMode = PickingMode.Ignore;
                textElement.pickingMode = PickingMode.Ignore;
            }

            void AddFieldToStyleClass()
            {
                field.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Text_Field_Input);
                textElement.AddToClassList(StyleConfig.Text_Field_Element);
            }

            void ShowDefaultTitle()
            {
                view.Value = "";
            }
        }
    }
}