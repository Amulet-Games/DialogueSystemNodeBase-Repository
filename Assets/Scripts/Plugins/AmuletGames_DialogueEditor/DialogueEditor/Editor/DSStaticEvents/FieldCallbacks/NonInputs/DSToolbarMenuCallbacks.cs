using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSToolbarMenuCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Register a new dropdown menu action, which when it's invoked, DSWindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="dropdownMenuItemClickedAction">The action to invoke when the dropdown menu item is clicked.</param>
        /// <param name="actionPara">Parameter used in menu option action.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> RegisterDropdownMenuAction<T>
        (
            Action<T> dropdownMenuItemClickedAction,
            T actionPara
        )
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(_ =>
            {
                dropdownMenuItemClickedAction.Invoke(actionPara);

                InvokeDSWindowChangedEvent();
            });

            return action;
        }


        /// <summary>
        /// Register a new dropdown menu action, which when it's invoked, DSWindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <param name="menuOptionClickedAction">The action to invoke when the dropdown menu item is clicked.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> RegisterDropdownMenuAction
        (
            Action dropdownMenuItemClickedAction
        )
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(_ =>
            {
                dropdownMenuItemClickedAction.Invoke();

                InvokeDSWindowChangedEvent();
            });

            return action;
        }
    }
}