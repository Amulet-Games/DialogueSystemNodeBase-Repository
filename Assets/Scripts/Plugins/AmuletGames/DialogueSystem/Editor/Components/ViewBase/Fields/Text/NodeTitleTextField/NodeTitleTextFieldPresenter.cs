using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeTitleTextFieldPresenter
    {
        /// <summary>
        /// Create a new node title text field element.
        /// </summary>
        /// <param name="view">The node title text field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        public static void CreateElement
        (
            NodeTitleTextFieldView view,
            string fieldUSS
        )
        {
            TextField field;
            VisualElement fieldInput;
            VisualElement textElement;

            CreateField();

            SetFieldDetails();

            SetupStyleClass();

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
                field.maxLength = NumberConfig.MAX_CHAR_LENGTH_NODE_TITLE_TEXT;

                fieldInput.pickingMode = PickingMode.Ignore;
                textElement.pickingMode = PickingMode.Ignore;
            }

            void SetupStyleClass()
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