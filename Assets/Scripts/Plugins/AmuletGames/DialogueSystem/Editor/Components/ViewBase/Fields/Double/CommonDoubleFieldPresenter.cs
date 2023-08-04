using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonDoubleFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common double field element.
        /// </summary>
        /// <param name="view">The common double field view to set for the field.</param>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new common double field element.</returns>
        public static void CreateElement
        (
            CommonDoubleFieldView view,
            string fieldUSS
        )
        {
            DoubleField field;

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
                fieldInput.AddToClassList(StyleConfig.Double_Field_Input);
                textElement.AddToClassList(StyleConfig.Double_Field_Element);
            }

            void ShowEmptyStyle()
            {
                field.ShowEmptyStyle();
            }
        }
    }
}