using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownElement : VisualElement
    {
        /// <summary>
        /// Image for the element icon.
        /// </summary>
        public Image IconImage;


        /// <summary>
        /// Label for the element text.
        /// </summary>
        public Label TextLabel;


        /// <summary>
        /// The element's additional info.
        /// </summary>
        public string AdditionalInfo;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the dropdown element selected status.
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