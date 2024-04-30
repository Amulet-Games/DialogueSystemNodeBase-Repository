using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldPresenter
    {
        /// <summary>
        /// Create the elements for the language text field view.
        /// </summary>
        /// <param name="view">The language text field view to set for..</param>
        /// <param name="multiline">Set this to true to allow multiple lines in the text field and false if otherwise.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        public static void CreateElement
        (
            LanguageTextFieldView view,
            bool multiline,
            string fieldUSS
        )
        {
            TextField field;
            VisualElement fieldInputElement;
            VisualElement fieldMultilineContainerElement;
            VisualElement fieldTextElement;

            CreateField();

            SetupDetails();

            AddStyleClass();

            SetupDefaultValue();

            void CreateField()
            {
                view.Field = new
                (
                    maxLength: multiline ? NumberConfig.MAX_CHAR_LENGTH_MULTI_LINE_TEXT_FIELD : NumberConfig.MAX_CHAR_LENGTH_SINGLE_LINE_TEXT_FIELD,
                    multiline: multiline,
                    isPasswordField: false,
                    maskChar: '*'
                );
                var (inputElement, multilineContainerElement, textElement) = view.Field.GetInitialChildElements();

                field = view.Field;
                fieldInputElement = inputElement;
                fieldMultilineContainerElement = multilineContainerElement;
                fieldTextElement = textElement;
            }

            void SetupDetails()
            {
                field.multiline = multiline;

                if (multiline)
                {
                    // WhiteSpace.Normal means the texts will auto line break when
                    // it reaches the end of the field input element.
                    field.style.whiteSpace = WhiteSpace.Normal;
                }
                else
                {
                    // WhiteSpace.NoWarp means the texts are shown in one line even when
                    // it's expanded outside of the field input element.
                    field.style.whiteSpace = WhiteSpace.NoWrap;
                }

                field.pickingMode = PickingMode.Position;
            }

            void AddStyleClass()
            {
                field.ClearClassList();
                fieldInputElement.ClearClassList();
                fieldTextElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInputElement.AddToClassList(StyleConfig.Text_Field_Input);
                fieldTextElement.AddToClassList(StyleConfig.Text_Field_Element);

                if (multiline)
                {
                    fieldMultilineContainerElement.ClearClassList();
                    fieldMultilineContainerElement.AddToClassList(StyleConfig.Text_Field_Multiline_Container);
                }
            }

            void SetupDefaultValue()
            {
                view.CurrentLanguageValue = "";
            }
        }
    }
}