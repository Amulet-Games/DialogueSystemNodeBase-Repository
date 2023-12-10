using UnityEngine.UIElements;

namespace AG.DS
{
    public static class DropdownElementExtensions
    {
        /// <summary>
        /// Add or remove the dropdown element's selected style class based on the certain condition.
        /// </summary>
        /// <param name="dropdownElement">Extension dropdown element.</param>
        public static void ToggleSelectedStyle(this DropdownElement dropdownElement)
        {
            if (dropdownElement.pickingMode == PickingMode.Ignore)
            {
                ShowSelectedStyle(dropdownElement);
            }
            else
            {
                HideSelectedStyle(dropdownElement);
            }
        }


        /// <summary>
        /// Remove the dropdown element from the selected style class.
        /// </summary>
        /// <param name="dropdownElement">Extension dropdown element.</param>
        public static void HideSelectedStyle(this DropdownElement dropdownElement)
        {
            dropdownElement.RemoveFromClassList(StyleConfig.DropdownElement_Selected);
        }


        /// <summary>
        /// Add the dropdown element to the selected style class.
        /// </summary>
        /// <param name="dropdownElement">Extension dropdown element.</param>
        public static void ShowSelectedStyle(this DropdownElement dropdownElement)
        {
            dropdownElement.AddToClassList(StyleConfig.DropdownElement_Selected);
        }


        /// <summary>
        /// Add the dropdown element to the last element style class.
        /// </summary>
        /// <param name="dropdownElement">Extension dropdown element.</param>
        public static void ShowLastElementStyle(this DropdownElement dropdownElement)
        {
            dropdownElement.AddToClassList(StyleConfig.DropdownElement_Last);
        }
    }
}