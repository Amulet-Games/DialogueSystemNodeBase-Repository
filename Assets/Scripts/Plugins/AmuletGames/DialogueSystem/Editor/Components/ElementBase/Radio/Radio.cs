using UnityEngine.UIElements;

namespace AG.DS
{
    public class Radio : VisualElement
    {
        /// <summary>
        /// Image for the radio icon.
        /// </summary>
        public Image IconImage;


        /// <summary>
        /// Label for the radio text.
        /// </summary>
        public Label TextLabel;


        // ----------------------------- Service -----------------------------
        /// <summary
        /// Set the radio element active status.
        /// </summary>
        /// <param name="active">The active value to set for.</param>
        public void SetActive(bool active)
        {
            pickingMode = active ? PickingMode.Ignore : PickingMode.Position;
            IconImage.pickingMode = active ? PickingMode.Ignore : PickingMode.Position;
            TextLabel.pickingMode = active ? PickingMode.Ignore : PickingMode.Position;
            this.ToggleActiveStyle();
        }
    }
}