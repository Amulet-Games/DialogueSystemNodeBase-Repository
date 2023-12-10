using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownElement : VisualElement
    {
        /// <summary>
        /// Image for the dropdown element icon.
        /// </summary>
        public Image ElementIconImage;


        /// <summary>
        /// Label for the dropdown element text.
        /// </summary>
        public Label ElementTextLabel;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the dropdown element active status.
        /// </summary>
        /// <param name="selected">The selected value to set for.</param>
        public void SetSelected(bool selected)
        {
            pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            ElementIconImage.pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            ElementTextLabel.pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            this.ToggleSelectedStyle();
        }
    }
}