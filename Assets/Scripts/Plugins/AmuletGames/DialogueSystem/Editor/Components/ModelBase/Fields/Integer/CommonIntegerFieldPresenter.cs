using UnityEditor.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common integer field UIElement.
        /// </summary>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new common integer field UIElement.</returns>
        public static IntegerField CreateElements(string fieldUSS01)
        {
            IntegerField commonIntegerField = new();

            commonIntegerField.AddToClassList(fieldUSS01);

            return commonIntegerField;
        }
    }
}