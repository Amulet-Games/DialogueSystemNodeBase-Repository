using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonLabelPresenter
    {
        /// <summary>
        /// Method for creating a new common Label element.
        /// </summary>
        /// <param name="labelText">The text to set for the label.</param>
        /// <param name="labelUSS">The USS style to set for the label.</param>
        /// <returns>A new common Label element.</returns>
        public static Label CreateElement
        (
            string labelText,
            string labelUSS
        )
        {
            Label label = new(labelText);

            label.ClearClassList();
            label.AddToClassList(labelUSS);

            return label;
        }
    }
}