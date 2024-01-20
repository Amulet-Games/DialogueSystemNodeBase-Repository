using System.Linq;

namespace AG.DS
{
    public class DropdownCallback
    {
        /// <summary>
        /// The callback to invoke when the dropdown element is created on the graph by the system or user.
        /// </summary>
        /// <param name="dropdown">The dropdown element to set for.</param>
        public static void OnCreate(Dropdown dropdown)
        {
            dropdown.Dropped = false;
        }


        /// <summary>
        /// The callback to invoke when the dropdown element is created on the graph by the user.
        /// </summary>
        /// <param name="dropdown">The dropdown element to set for.</param>
        public static void OnCreateByUser(Dropdown dropdown)
        {
            dropdown.SelectedItem = dropdown.DropdownItems.First();
        }
    }
}