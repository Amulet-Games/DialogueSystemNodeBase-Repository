using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldPresenter
    {
        /// <summary>
        /// Create a new graph title text field element.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <returns>A new graph title text field element.</returns>
        public static TextField CreateElement
        (
            GraphTitleTextFieldView view,
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

            return field;

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
                view.BindingSO = null;
            }
        }
    }
}