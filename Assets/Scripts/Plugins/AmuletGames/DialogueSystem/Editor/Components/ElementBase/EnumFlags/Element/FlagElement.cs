using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FlagElement<TEnum> : VisualElement
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Image for the element selected icon.
        /// </summary>
        public Image SelectedIconImage;


        /// <summary>
        /// Label for the element text.
        /// </summary>
        public Label TextLabel;


        /// <summary>
        /// The element's flag.
        /// </summary>
        public TEnum Flag;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the flag element selected status.
        /// </summary>
        /// <param name="selected">The selected value to set for.</param>
        public void SetSelected(bool selected)
        {
            SelectedIconImage.SetVisibility(selected);
        }
    }
}