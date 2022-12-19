using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ToolbarMenuCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Register a new dropdown menu action, which when it's invoked, WindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="menuItemClickedAction">The action to invoke when the dropdown menu item is clicked.</param>
        /// <param name="actionPara">Parameter used in menu option action.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> RegisterDropdownMenuAction<T>
        (
            Action<T> menuItemClickedAction,
            T actionPara
        )
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(callback =>
            {
                menuItemClickedAction.Invoke(actionPara);

                InvokeWindowChangedEvent();
            });

            return action;
        }


        /// <summary>
        /// Register a new dropdown menu action, which when it's invoked, WindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <param name="menuOptionClickedAction">The action to invoke when the dropdown menu item is clicked.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> RegisterDropdownMenuAction
        (
            Action menuItemClickedAction
        )
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(callback =>
            {
                menuItemClickedAction.Invoke();

                InvokeWindowChangedEvent();
            });

            return action;
        }
    }
}