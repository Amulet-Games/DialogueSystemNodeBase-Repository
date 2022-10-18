using UnityEngine.UIElements;

namespace AG
{
    public class DSLabelsMaker
    {
        /// <summary>
        /// Returns a new label UIElement.
        /// </summary>
        /// <param name="labelName">The contexts of the label.</param>
        /// <param name="USS01">The first style for the label to use when it appeared on the editor window.</param>
        /// <returns>A new label UIElement.</returns>
        public static Label GetNewLabel
        (
            string labelName,
            string USS01 = ""
        )
        {
            // Setup label
            Label label = new Label(labelName);

            // Add label to style class
            label.AddToClassList(USS01);

            return label;
        }
    }
}