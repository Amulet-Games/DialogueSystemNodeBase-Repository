using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownCallback
    {
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