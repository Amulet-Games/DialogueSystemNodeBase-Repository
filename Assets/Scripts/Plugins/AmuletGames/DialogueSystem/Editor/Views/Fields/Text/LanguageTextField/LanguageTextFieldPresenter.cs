using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldPresenter
    {
        /// <summary>
        /// Create the elements for the language text field view.
        /// </summary>
        /// <param name="view">The language text field view to set for..</param>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        /// <param name="multiline">Set this to true to allow multiple lines in the text field and false if otherwise.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <param name="fieldImageSprite">The field image sprite to set for.</param>
        public static void CreateElement
        (
            LanguageTextFieldView view,
            string placeholderText,
            bool multiline,
            string fieldUSS,
            Sprite fieldImageSprite = null
        )
        {
            TextField field;
            Image fieldImageElement = null;
            VisualElement fieldInputElement;
            VisualElement fieldMultilineContainerElement;
            VisualElement fieldTextElement;

            CreateField();

            CreateFieldImage();

            CreatePlaceholderLabel();

            AddStyleClass();

            SetupDetails();

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

            void CreateFieldImage()
            {
                if (fieldImageSprite)
                {
                    fieldImageElement = ImagePresenter.CreateElement
                    (
                        sprite: fieldImageSprite,
                        USS01: StyleConfig.Text_Field_Image
                    );
                }
            }

            void CreatePlaceholderLabel()
            {
                view.PlaceholderTextLabel = LabelPresenter.CreateElement
                (
                    text: placeholderText,
                    USS: StyleConfig.Text_Field_Placeholder_Label
                );
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

            void SetupDetails()
            {
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

                if (fieldImageElement != null)
                {
                    field.SetDisplayImage(fieldImageElement);
                }

                field.SetPlaceholderLabel(view.PlaceholderTextLabel);
            }
        }
    }
}