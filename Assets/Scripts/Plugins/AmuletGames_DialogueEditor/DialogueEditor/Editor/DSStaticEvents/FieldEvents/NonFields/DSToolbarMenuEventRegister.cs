using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSToolbarMenuEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Create and return a new dropdown menu action, which when it's invoked, DSWindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="menuOptionAction">The action that'll be invoked when menu option is clicked.</param>
        /// <param name="actionPara">Parameter used in menu option action.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> DSDropdownMenuAction<T>(Action<T> menuOptionAction, T actionPara)
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(_ =>
            {
                menuOptionAction.Invoke(actionPara);

                InvokeDSWindowChangedEvent();
            });

            return action;
        }


        /// <summary>
        /// Create and return a new dropdown menu action, which when it's invoked, DSWindowChangedEvent will get
        /// <br>invoked right after it as well.</br>
        /// </summary>
        /// <param name="menuOptionAction">The action that'll be invoked when menu option is clicked.</param>
        /// <returns>Returns a new dropdown menu action for toolbar menu element.</returns>
        public static Action<DropdownMenuAction> DSDropdownMenuAction(Action menuOptionAction)
        {
            Action<DropdownMenuAction> action = new Action<DropdownMenuAction>(_ =>
            {
                menuOptionAction.Invoke();

                InvokeDSWindowChangedEvent();
            });

            return action;
        }
    }
}