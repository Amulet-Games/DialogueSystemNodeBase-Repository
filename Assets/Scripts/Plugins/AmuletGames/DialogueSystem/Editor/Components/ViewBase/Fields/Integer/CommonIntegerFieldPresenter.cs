using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common integer field element.
        /// </summary>
        /// <param name="fieldUSS">The USS style to set for the field.</param>
        /// <returns>A new common integer field element.</returns>
        public static IntegerField CreateElement(string fieldUSS)
        {
            IntegerField commonIntegerField = new();

            commonIntegerField.AddToClassList(fieldUSS);

            return commonIntegerField;
        }
    }
}