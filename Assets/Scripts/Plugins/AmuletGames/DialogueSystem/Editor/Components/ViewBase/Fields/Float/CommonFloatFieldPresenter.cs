using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonFloatFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common float field element.
        /// </summary>
        /// <param name="iconSprite">The icon to set for field, it shows up next to the its input area.</param>
        /// <returns>A new common float field element.</returns>
        public static FloatField CreateElement(string fieldUSS01)
        {
            FloatField commonFloatField = new();

            commonFloatField.AddToClassList(fieldUSS01);

            return commonFloatField;
        }
    }
}