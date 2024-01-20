using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownItem : VisualElement
    {
        /// <summary>
        /// Image for the item icon.
        /// </summary>
        public Image IconImage;


        /// <summary>
        /// Label for the item text.
        /// </summary>
        public Label TextLabel;


        /// <summary>
        /// The item's additional info.
        /// </summary>
        public string AdditionalInfo;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the dropdown item selected status.
        /// </summary>
        /// <param name="selected">The selected value to set for.</param>
        public void SetSelected(bool selected)
        {
            pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            IconImage.pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            TextLabel.pickingMode = selected ? PickingMode.Ignore : PickingMode.Position;
            this.ToggleSelectedStyle();
        }
    }
}