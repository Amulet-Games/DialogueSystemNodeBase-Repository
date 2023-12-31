using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonLabelPresenter
    {
        /// <summary>
        /// Create a new common Label element.
        /// </summary>
        /// <param name="text">The text to set for.</param>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new common Label element.</returns>
        public static Label CreateElement
        (
            string text,
            string USS
        )
        {
            Label label = new(text);

            label.ClearClassList();
            label.AddToClassList(USS);

            return label;
        }
    }
}