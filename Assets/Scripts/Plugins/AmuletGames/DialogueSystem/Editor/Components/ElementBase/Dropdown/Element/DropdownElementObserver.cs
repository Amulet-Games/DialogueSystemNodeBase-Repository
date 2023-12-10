using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropElementObserver
    {
        /// <summary>
        /// The targeting dropdown element.
        /// </summary>
        DropdownElement dropdownElement;


        /// <summary>
        /// Reference of the dropdown element.
        /// </summary>
        Dropdown dropdown;


        /// <summary>
        /// Constructor of the dropdown element observer class.
        /// </summary>
        /// <param name="dropdownElement">The dropdown element to set for.</param>
        /// <param name="dropdown">The dropdown to set for.</param>
        public DropElementObserver
        (
            DropdownElement dropdownElement,
            Dropdown dropdown
        )
        {
            this.dropdownElement = dropdownElement;
            this.dropdown = dropdown;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dropdown element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register MouseDownEvent to the dropdown element.
        /// </summary>
        void RegisterMouseDownEvent() => dropdownElement.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the dropdown element.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            dropdown.SelectedElement = dropdownElement;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}