using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeTitleTextFieldPresenter
    {
        /// <summary>
        /// Create the elements for the node title text field view.
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
            VisualElement fieldInputElement;
            VisualElement fieldTextElement;

            CreateField();

            SetupDetails();

            AddStyleClass();

            SetupDefaultValue();

            void CreateField()
            {
                view.Field = new
                (
                    maxLength: NumberConfig.MAX_CHAR_LENGTH_NODE_TITLE_TEXT,
                    multiline: false,
                    isPasswordField: false,
                    maskChar: '*'
                );
                var (inputElement, multilineContainerElement, textElement) = view.Field.GetInitialChildElements();

                field = view.Field;
                fieldInputElement = inputElement;
                fieldTextElement = textElement;
            }

            void SetupDetails()
            {
                field.isDelayed = true;

                fieldInputElement.pickingMode = PickingMode.Ignore;
                fieldTextElement.pickingMode = PickingMode.Ignore;
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
            }
        }
    }
}