using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownObserver
    {
        /// <summary>
        /// The targeting dropdown element.
        /// </summary>
        Dropdown dropdown;


        /// <summary>
        /// The event to invoke when the dropdown selected item has changed.
        /// </summary>
        Action<string> selectedItemChangedEvent;


        /// <summary>
        /// Constructor of the dropdown observer class.
        /// </summary>
        /// <param name="dropdown">The dropdown element to set for.</param>
        /// <param name="selectedItemChangedEvent">The SelectedItemChangedEvent to set for.</param>
        public DropdownObserver
        (
            Dropdown dropdown,
            Action<string> selectedItemChangedEvent
        )
        {
            this.dropdown = dropdown;
            this.selectedItemChangedEvent = selectedItemChangedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dropdown element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterDropdownButtonFocusOutEvent();

            RegisterDropdownButtonMouseDownEvent();

            RegisterDropdownItemsEvents();

            RegisterSelectedItemChangedEvent();
        }


        /// <summary>
        /// Register FocusOutEvent to the dropdown button.
        /// </summary>
        void RegisterDropdownButtonFocusOutEvent() =>
            dropdown.DropdownButton.RegisterCallback<FocusOutEvent>(DropdownButtonFocusOutEvent);


        /// <summary>
        /// Register MouseDownEvent to the dropdown button.
        /// </summary>
        void RegisterDropdownButtonMouseDownEvent() =>
            dropdown.DropdownButton.RegisterCallback<MouseDownEvent>(DropdownButtonMouseDownEvent);


        /// <summary>
        /// Register events to the dropdown items.
        /// </summary>
        void RegisterDropdownItemsEvents()
        {
            var dropdownItems = dropdown.DropdownItems;
            for (int i = 0; i < dropdownItems.Length; i++)
            {
                new DropdownItemObserver(dropdownItems[i], dropdown).RegisterEvents();
            }
        }


        /// <summary>
        /// Register SelectedItemChangedEvent to the dropdown.
        /// </summary>
        void RegisterSelectedItemChangedEvent() =>
            dropdown.SelectedItemChangedEvent += DropdownSelectedItemChangedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the dropdown button has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void DropdownButtonFocusOutEvent(FocusOutEvent evt)
        {
            dropdown.Dropped = false;
        }


        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the dropdown button element.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void DropdownButtonMouseDownEvent(MouseDownEvent evt)
        {
            dropdown.Dropped = !dropdown.Dropped;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }


        /// <summary>
        /// The event to invoke when the dropdown selected item has changed.
        /// </summary>
        void DropdownSelectedItemChangedEvent()
        {
            selectedItemChangedEvent.Invoke(dropdown.SelectedItem.AdditionalInfo);
        }
    }
}