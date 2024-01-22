using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFlagsItem<TEnum> : VisualElement
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Image for the checkmark icon.
        /// </summary>
        public Image CheckmarkImage;


        /// <summary>
        /// Label for the item text.
        /// </summary>
        public Label TextLabel;


        /// <summary>
        /// The item's flag.
        /// </summary>
        public TEnum Flag;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the item selected status.
        /// </summary>
        /// <param name="selected">The selected value to set for.</param>
        public void SetSelected(bool selected)
        {
            CheckmarkImage.SetVisibility(selected);
        }
    }
}