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
        /// Constructor of the dropdown observer class.
        /// </summary>
        /// <param name="dropdown">The dropdown to set for.</param>
        public DropdownObserver(Dropdown dropdown)
        {
            this.dropdown = dropdown;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dropdown elements.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterDropdownButtonFocusInEvent();

            RegisterDropdownButtonFocusOutEvent();

            RegisterDropdownButtonMouseDownEvent();

            RegisterDropElementEvents();
        }


        /// <summary>
        /// Register FocusInEvent to the dropdown button.
        /// </summary>
        void RegisterDropdownButtonFocusInEvent() =>
            dropdown.DropdownButton.RegisterCallback<FocusInEvent>(DropdownButtonFocusInEvent);


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


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the dropdown button has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void DropdownButtonFocusInEvent(FocusInEvent evt)
        {
            dropdown.Dropped = true;
        }


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
            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}