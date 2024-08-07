using System;

namespace AG.DS
{
    public class BindingFlagsObserver : EnumFlagsObserverFrameBase<BindingFlags.Bindings>
    {
        /// <summary>
        /// Constructor of the binding flags observer class.
        /// </summary>
        /// <param name="enumFlags">The enum flags to set for.</param>
        /// <param name="selectedItemsChangedEvent">The selectedItemsChangedEvent to set for.</param>
        public BindingFlagsObserver
        (
            EnumFlagsFrameBase<BindingFlags.Bindings> enumFlags,
            Action<BindingFlags.Bindings> selectedItemsChangedEvent
        )
            : base(enumFlags, selectedItemsChangedEvent)
        {
        }
    }
}