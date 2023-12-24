using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FlagElementObserver<TEnum>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// The targeting flag element.
        /// </summary>
        FlagElement<TEnum> flagElement;


        /// <summary>
        /// Reference of the enum flags element.
        /// </summary>
        EnumFlagsFrameBase<TEnum> enumFlags;


        /// <summary>
        /// Constructor of the flag element observer class.
        /// </summary>
        /// <param name="flagElement">The flag element to set for.</param>
        /// <param name="enumFlags">The enum flags to set for.</param>
        public FlagElementObserver
        (
            FlagElement<TEnum> flagElement,
            EnumFlagsFrameBase<TEnum> enumFlags
        )
        {
            this.flagElement = flagElement;
            this.enumFlags = enumFlags;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the flag element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register MouseDownEvent to the flag element.
        /// </summary>
        void RegisterMouseDownEvent() => flagElement.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the flag element.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            enumFlags.LastSelectedFlagElement = flagElement;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}