using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldPresenter
    {
        /// <summary>
        /// Create the elements for the graph title text field view.
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
            VisualElement fieldInputElement;
            VisualElement fieldTextElement;

            CreateField();

            SetupDetails();

            AddStyleClass();

            SetupDefaultValue();

            return field;

            void CreateField()
            {
                view.Field = new();
                var (inputElement, multilineContainerElement, textElement) = view.Field.GetInitialChildElements();

                field = view.Field;
                fieldInputElement = inputElement;
                fieldTextElement = textElement;
            }

            void SetupDetails()
            {
                field.isDelayed = true;
            }

            void AddStyleClass()
            {
                field.ClearClassList();
                fieldInputElement.ClearClassList();
                fieldTextElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInputElement.AddToClassList(StyleConfig.Text_Field_Input);
                fieldTextElement.AddToClassList(StyleConfig.Text_Field_Element);
            }

            void SetupDefaultValue()
            {
                view.Value = "";
                view.BindingSO = null;
            }
        }
    }
}