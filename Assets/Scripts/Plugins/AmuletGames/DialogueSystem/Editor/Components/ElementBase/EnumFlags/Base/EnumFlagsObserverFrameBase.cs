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
        /// The event to invoke when the enum flags selected flags has changed.
        /// </summary>
        Action<TEnum> selectedFlagsChangedEvent;


        /// <summary>
        /// Constructor of the enum flags observer class.
        /// </summary>
        /// <param name="enumFlags">The enum flags to set for.</param>
        /// <param name="selectedFlagsChangedEvent">The selectedFlagsChangedEvent to set for.</param>
        public EnumFlagsObserverFrameBase
        (
            EnumFlagsFrameBase<TEnum> enumFlags,
            Action<TEnum> selectedFlagsChangedEvent
        )
        {
            this.enumFlags = enumFlags;
            this.selectedFlagsChangedEvent = selectedFlagsChangedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the enum flags elements.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEnumFlagsButtonFocusOutEvent();

            RegisterEnumFlagsButtonMouseDownEvent();

            RegisterFlagElementEvents();

            RegisterSelectedFlagsChangedEvent();
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


        void RegisterFlagElementEvents()
        {
            var flagElements = enumFlags.FlagElements;
            for (int i = 0; i < flagElements.Length; i++)
            {
                new FlagElementObserver<TEnum>(flagElements[i], enumFlags).RegisterEvents();
            }
        }


        /// <summary>
        /// Register SelectedFlagsChangedEvent to the enum flags.
        /// </summary>
        void RegisterSelectedFlagsChangedEvent() =>
            enumFlags.SelectedFlagsChangedEvent += EnumFlagsSelectedFlagsChangedEvent;


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


        /// <summary>
        /// The event to invoke when the enum flags selected flags has changed.
        /// </summary>
        void EnumFlagsSelectedFlagsChangedEvent()
        {
            selectedFlagsChangedEvent?.Invoke(enumFlags.SelectedFlags);
        }
    }
}