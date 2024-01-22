using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFlagsItemObserver<TEnum>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// The targeting enum flags item element.
        /// </summary>
        EnumFlagsItem<TEnum> enumFlagsItem;


        /// <summary>
        /// Reference of the enum flags element.
        /// </summary>
        EnumFlagsFrameBase<TEnum> enumFlags;


        /// <summary>
        /// Constructor of the enum flags item observer class.
        /// </summary>
        /// <param name="enumFlagsItem">The enum flags item to set for.</param>
        /// <param name="enumFlags">The enum flags to set for.</param>
        public EnumFlagsItemObserver
        (
            EnumFlagsItem<TEnum> enumFlagsItem,
            EnumFlagsFrameBase<TEnum> enumFlags
        )
        {
            this.enumFlagsItem = enumFlagsItem;
            this.enumFlags = enumFlags;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the enum flags item.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register MouseDownEvent to the enum flags item.
        /// </summary>
        void RegisterMouseDownEvent() => enumFlagsItem.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the enum flags item.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            enumFlags.LastSelectedItem = enumFlagsItem;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}