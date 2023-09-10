using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonLabelPresenter
    {
        /// <summary>
        /// Create a new common Label element.
        /// </summary>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="labelUSS">The label USS style to set for.</param>
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