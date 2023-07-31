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
            DoubleField doubleField;

            CreateField();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            void CreateField()
            {
                view.DoubleField = new();
                doubleField = view.DoubleField;
            }

            void AddFieldToStyleClass()
            {
                var fieldInput = doubleField.GetFieldInput();
                var textElement = doubleField.GetTextElement();

                doubleField.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                doubleField.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Double_Field_Input);
                textElement.AddToClassList(StyleConfig.Double_Field_Element);
            }

            void ShowEmptyStyle()
            {
                doubleField.ShowEmptyStyle();
            }
        }
    }
}