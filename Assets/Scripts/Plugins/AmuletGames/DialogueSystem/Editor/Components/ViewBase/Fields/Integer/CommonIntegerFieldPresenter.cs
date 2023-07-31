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
            IntegerField integerField;

            CreateField();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            void CreateField()
            {
                view.IntegerField = new();
                integerField = view.IntegerField;
            }

            void AddFieldToStyleClass()
            {
                var fieldInput = integerField.GetFieldInput();
                var textElement = integerField.GetTextElement();

                integerField.ClearClassList();
                fieldInput.ClearClassList();
                textElement.ClearClassList();

                integerField.AddToClassList(fieldUSS);
                fieldInput.AddToClassList(StyleConfig.Integer_Field_Input);
                textElement.AddToClassList(StyleConfig.Integer_Field_Element);
            }

            void ShowEmptyStyle()
            {
                integerField.ShowEmptyStyle();
            }
        }
    }
}