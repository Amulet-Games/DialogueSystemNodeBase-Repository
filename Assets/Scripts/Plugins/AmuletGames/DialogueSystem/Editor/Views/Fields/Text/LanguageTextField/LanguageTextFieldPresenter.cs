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

            CreateField();

            SetupDetails();

            AddStyleClass();

            SetupDefaultValue();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
            }

            void SetupDetails()
            {
                field.multiline = multiline;

                if (multiline)
                {
                    // WhiteSpace.Normal means the texts will auto line break when
                    // it reaches the end of the field input element.

                    field.maxLength = NumberConfig.MAX_CHAR_LENGTH_MULTI_LINE_TEXT_FIELD;
                    field.style.whiteSpace = WhiteSpace.Normal;
                }
                else
                {
                    // WhiteSpace.NoWarp means the texts are shown in one line even when
                    // it's expanded outside of the field input element.

                    field.maxLength = NumberConfig.MAX_CHAR_LENGTH_SINGLE_LINE_TEXT_FIELD;
                    field.style.whiteSpace = WhiteSpace.NoWrap;
                }

                field.pickingMode = PickingMode.Position;
            }

            void AddStyleClass()
            {
                var fieldInput = field.GetFieldInput();
                var textElement = field.GetTextElement();

                field.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Text_Field_Input);
                textElement.AddToClassList(StyleConfig.Text_Field_Element);

                if (multiline)
                {
                    var fieldMultilineContainer = field.GetMultilineContainer();
                    fieldMultilineContainer.ClearClassList();
                    fieldMultilineContainer.AddToClassList(StyleConfig.Text_Field_Multiline_Container);
                }
            }

            void SetupDefaultValue()
            {
                view.CurrentLanguageValue = "";
            }
        }
    }
}