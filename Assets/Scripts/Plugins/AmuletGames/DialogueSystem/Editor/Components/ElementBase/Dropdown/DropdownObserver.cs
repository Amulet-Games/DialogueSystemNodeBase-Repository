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
        /// The event to invoke when the dropdown selected element has changed.
        /// </summary>
        Action<string> selectedElementChangedEvent;


        /// <summary>
        /// Constructor of the dropdown observer class.
        /// </summary>
        /// <param name="dropdown">The dropdown to set for.</param>
        /// <param name="selectedElementChangedEvent">The SelectedElementChangedEvent to set for.</param>
        public DropdownObserver
        (
            Dropdown dropdown,
            Action<string> selectedElementChangedEvent
        )
        {
            this.dropdown = dropdown;
            this.selectedElementChangedEvent = selectedElementChangedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dropdown elements.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterDropdownButtonFocusOutEvent();

            RegisterDropdownButtonMouseDownEvent();

            RegisterDropElementEvents();

            RegisterSelectedElementChangedEvent();
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
        /// Register events to the dropdown elements.
        /// </summary>
        void RegisterDropElementEvents()
        {
            var dropElements = dropdown.DropdownElements;
            for (int i = 0; i < dropElements.Length; i++)
            {
                new DropElementObserver(dropElements[i], dropdown).RegisterEvents();
            }
        }


        /// <summary>
        /// Register SelectedElementChangedEvent to the dropdown.
        /// </summary>
        void RegisterSelectedElementChangedEvent() =>
            dropdown.SelectedElementChangedEvent += DropdownSelectedElementChangedEvent;


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
        /// The event to invoke when the dropdown selected element has changed.
        /// </summary>
        void DropdownSelectedElementChangedEvent()
        {
            selectedElementChangedEvent.Invoke(dropdown.SelectedElement.AdditionalInfo);
        }
    }
}