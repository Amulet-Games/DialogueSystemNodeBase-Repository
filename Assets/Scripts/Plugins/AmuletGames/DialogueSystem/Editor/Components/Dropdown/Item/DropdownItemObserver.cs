using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownItemObserver
    {
        /// <summary>
        /// The targeting dropdown item element.
        /// </summary>
        DropdownItem dropdownItem;


        /// <summary>
        /// Reference of the dropdown element.
        /// </summary>
        Dropdown dropdown;


        /// <summary>
        /// Constructor of the dropdown item observer class.
        /// </summary>
        /// <param name="dropdownItem">The dropdown item to set for.</param>
        /// <param name="dropdown">The dropdown element to set for.</param>
        public DropdownItemObserver
        (
            DropdownItem dropdownItem,
            Dropdown dropdown
        )
        {
            this.dropdownItem = dropdownItem;
            this.dropdown = dropdown;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dropdown item.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register MouseDownEvent to the dropdown item.
        /// </summary>
        void RegisterMouseDownEvent() => dropdownItem.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the dropdown item.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            dropdown.SelectedItem = dropdownItem;

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}