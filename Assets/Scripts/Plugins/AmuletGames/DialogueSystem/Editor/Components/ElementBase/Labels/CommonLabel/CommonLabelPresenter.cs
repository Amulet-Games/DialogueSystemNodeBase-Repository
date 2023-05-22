using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonLabelPresenter
    {
        /// <summary>
        /// Method for creating a new common Label element.
        /// </summary>
        /// <param name="labelText">The text to set for the label.</param>
        /// <param name="labelUSS01">The first USS style to set for the label.</param>
        /// <returns>A new common Label element.</returns>
        public static Label CreateElement
        (
            string labelText,
            string labelUSS01
        )
        {
            Label label = new(labelText);

            label.AddToClassList(labelUSS01);

            return label;
        }
    }
}