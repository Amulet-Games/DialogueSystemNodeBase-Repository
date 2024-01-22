using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFlagsObserverFrameBase<TEnum> where TEnum : struct, Enum
    {
        /// <summary>
        /// The targeting enum flags element.
        /// </summary>
        EnumFlagsFrameBase<TEnum> enumFlags;


        /// <summary>
        /// The event to invoke when the enum flags's selected enum flags item has changed.
        /// </summary>
        Action<TEnum> selectedItemsChangedEvent;


        /// <summary>
        /// Constructor of the enum flags observer class.
        /// </summary>
        /// <param name="enumFlags">The enum flags to set for.</param>
        /// <param name="selectedItemsChangedEvent">The selectedItemsChangedEvent to set for.</param>
        public EnumFlagsObserverFrameBase
        (
            EnumFlagsFrameBase<TEnum> enumFlags,
            Action<TEnum> selectedItemsChangedEvent
        )
        {
            this.enumFlags = enumFlags;
            this.selectedItemsChangedEvent = selectedItemsChangedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the enum flags elements.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEnumFlagsButtonFocusOutEvent();

            RegisterEnumFlagsButtonMouseDownEvent();

            RegisterEnumFlagsItemEvents();

            RegisterSelectedItemsChangedEvent();
        }


        /// <summary>
        /// Register FocusOutEvent to the enum flags button.
        /// </summary>
        void RegisterEnumFlagsButtonFocusOutEvent() =>
            enumFlags.EnumFlagsButton.RegisterCallback<FocusOutEvent>(EnumFlagsButtonFocusOutEvent);


        /// <summary>
        /// Register MouseDownEvent to the enum flags button.
        /// </summary>
        void RegisterEnumFlagsButtonMouseDownEvent() =>
            enumFlags.EnumFlagsButton.RegisterCallback<MouseDownEvent>(EnumFlagsButtonMouseDownEvent);


        /// <summary>
        /// Register events to the enum flags items.
        /// </summary>
        void RegisterEnumFlagsItemEvents()
        {
            var enumFlagsItem = enumFlags.Items;
            for (int i = 0; i < enumFlagsItem.Length; i++)
            {
                new EnumFlagsItemObserver<TEnum>(enumFlagsItem[i], enumFlags).RegisterEvents();
            }
        }


        /// <summary>
        /// Register SelectedItemsChangedEvent to the enum flags.
        /// </summary>
        void RegisterSelectedItemsChangedEvent() => enumFlags.SelectedItemsChangedEvent += selectedItemsChangedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the enum flags button has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void EnumFlagsButtonFocusOutEvent(FocusOutEvent evt)
        {
            enumFlags.Dropped = false;
        }


        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the enum flags button element.
        /// </summary>
        /// <param name="evt"></param>
        void EnumFlagsButtonMouseDownEvent(MouseDownEvent evt)
        {
            enumFlags.Dropped = !enumFlags.Dropped;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}