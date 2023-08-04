using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common integer field element.
        /// </summary>
        /// <param name="view">The common integer field view to set for the field.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        public static void CreateElement
        (
            CommonIntegerFieldView view,
            string fieldUSS
        )
        {
            IntegerField field;

            CreateField();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            void CreateField()
            {
                view.Field = new();
                field = view.Field;
            }

            void AddFieldToStyleClass()
            {
                var fieldInput = field.GetFieldInput();
                var textElement = field.GetTextElement();

                field.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Integer_Field_Input);
                textElement.AddToClassList(StyleConfig.Integer_Field_Element);
            }

            void ShowEmptyStyle()
            {
                field.ShowEmptyStyle();
            }
        }
    }
}