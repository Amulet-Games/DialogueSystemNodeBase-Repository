using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldPresenter
    {
        /// <summary>
        /// Create the elements for the integer field view.
        /// </summary>
        /// <param name="view">The common integer field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        public static void CreateElement
        (
            CommonIntegerFieldView view,
            string fieldUSS
        )
        {
            IntegerField field;

            CreateField();

            SetupDetails();

            AddStyleClass();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
            }

            void SetupDetails()
            {
                view.Value = 0;
            }

            void AddStyleClass()
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
        }
    }
}