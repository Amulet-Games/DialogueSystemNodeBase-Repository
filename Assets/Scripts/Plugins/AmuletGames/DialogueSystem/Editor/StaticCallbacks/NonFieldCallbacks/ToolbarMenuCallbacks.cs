using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ToolbarMenuCallbacks
    {
        /// <summary>
        /// Returns a new dropdown menu action that will invoke <see cref="WindowChangedEvent"/> afterward, when the given click actions have finished their process.
        /// </summary>
        /// <param name="dropdownMenuAction">The action to invoke when the toolbar menu item is clicked.</param>
        /// <param name="dropdownMenuActionParameter">The parameter to give to the dropdown menu action.</param>
        /// <returns>Returns a new dropdown menu action that will invoke <see cref="WindowChangedEvent"/> afterward.</returns>
        public static Action<DropdownMenuAction> GetDropdownMenuAction<T>
        (
            Action<T> dropdownMenuAction,
            T dropdownMenuActionParameter
        )
        {
            return new Action<DropdownMenuAction>(callback =>
            {
                dropdownMenuAction.Invoke(dropdownMenuActionParameter);

                WindowChangedEvent.Invoke();
            });
        }


        /// <summary>
        /// Returns a new dropdown menu action that won't invoke <see cref="WindowChangedEvent"/> afterward, when the given click actions have finished their process.
        /// </summary>
        /// <param name="dropdownMenuAction">The action to invoke when the toolbar menu item is clicked.</param>
        /// <returns>Returns a new dropdown menu action that will invoke <see cref="WindowChangedEvent"/> afterward.</returns>
        public static Action<DropdownMenuAction> GetDropdownMenuAction
        (
            Action dropdownMenuAction
        )
        {
            return new Action<DropdownMenuAction>(callback =>
            {
                dropdownMenuAction.Invoke();

                WindowChangedEvent.Invoke();
            });
        }
    }
}