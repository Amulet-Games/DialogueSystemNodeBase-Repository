using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonDoubleFieldPresenter
    {
        /// <summary>
        /// Create a new common double field element.
        /// </summary>
        /// <param name="view">The common double field view to set for.</param>
        /// <param name="fieldUSS">The field USS style to set for.</param>
        /// <returns>A new common double field element.</returns>
        public static void CreateElement
        (
            CommonDoubleFieldView view,
            string fieldUSS
        )
        {
            DoubleField field;

            CreateField();

            AddStyleClass();

            ShowEmptyStyleByDefault();

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
                fieldInput.AddToClassList(StyleConfig.Double_Field_Input);
                textElement.AddToClassList(StyleConfig.Double_Field_Element);
            }

            void ShowEmptyStyleByDefault()
            {
                field.ShowEmptyStyle();
            }
        }
    }
}