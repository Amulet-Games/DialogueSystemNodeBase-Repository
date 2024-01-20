using UnityEngine.UIElements;

namespace AG.DS
{
    public static class DropdownItemExtensions
    {
        /// <summary>
        /// Add or remove the dropdown item's selected style class based on the certain condition.
        /// </summary>
        /// <param name="dropdownItem">Extension dropdown item.</param>
        public static void ToggleSelectedStyle(this DropdownItem dropdownItem)
        {
            if (dropdownItem.pickingMode == PickingMode.Ignore)
            {
                ShowSelectedStyle(dropdownItem);
            }
            else
            {
                HideSelectedStyle(dropdownItem);
            }
        }


        /// <summary>
        /// Remove the dropdown item from the selected style class.
        /// </summary>
        /// <param name="dropdownItem">Extension dropdown item.</param>
        public static void HideSelectedStyle(this DropdownItem dropdownItem)
        {
            dropdownItem.RemoveFromClassList(StyleConfig.DropdownItem_Selected);
        }


        /// <summary>
        /// Add the dropdown item to the selected style class.
        /// </summary>
        /// <param name="dropdownItem">Extension dropdown item.</param>
        public static void ShowSelectedStyle(this DropdownItem dropdownItem)
        {
            dropdownItem.AddToClassList(StyleConfig.DropdownItem_Selected);
        }


        /// <summary>
        /// Add the dropdown item to the last item style class.
        /// </summary>
        /// <param name="dropdownItem">Extension dropdown item.</param>
        public static void ShowLastStyle(this DropdownItem dropdownItem)
        {
            dropdownItem.AddToClassList(StyleConfig.DropdownItem_Last);
        }
    }
}