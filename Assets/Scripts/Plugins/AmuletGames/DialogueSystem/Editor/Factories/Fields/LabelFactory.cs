using UnityEngine.UIElements;

namespace AG.DS
{
    public class LabelFactory
    {
        /// <summary>
        /// Factory method for creating a new label UIElement.
        /// </summary>
        /// <param name="labelText">The contexts of the label.</param>
        /// <param name="labelUSS01">The first USS style to set for the label.</param>
        /// <returns>A new label UIElement.</returns>
        public static Label GetNewLabel
        (
            string labelText,
            string labelUSS01 = ""
        )
        {
            // Setup label
            Label label = new Label(labelText);

            // Add label to style class
            label.AddToClassList(labelUSS01);

            return label;
        }
    }
}