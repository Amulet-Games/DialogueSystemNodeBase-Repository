using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonFloatFieldPresenter
    {
        /// <summary>
        /// Create the elements for the float field view.
        /// </summary>
        /// <param name="view">The common float field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <returns>A new common float field element.</returns>
        public static void CreateElement
        (
            CommonFloatFieldView view,
            string fieldUSS
        )
        {
            FloatField field;

            CreateField();

            AddStyleClass();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
            }

            void AddStyleClass()
            {
                var fieldInput = field.GetFieldInput();
                var textElement = field.GetTextElement();

                field.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                field.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Float_Field_Input);
                textElement.AddToClassList(StyleConfig.Float_Field_Element);
            }
        }
    }
}