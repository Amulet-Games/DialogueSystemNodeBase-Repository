using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSToolbarMenuUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Create and return a new drop down menu action,
        /// which will call DSWindowChangedEvent along side with it's menu element action.
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="menuOptionAction">The action that'll get invoked when menu option is clicked.</param>
        /// <param name="actionPara">Parameter used in menu option action.</param>
        /// <returns></returns>
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
        /// Create and return a new drop down menu action,
        /// which will call DSWindowChangedEvent along side with it's menu element action.
        /// </summary>
        /// <param name="menuOptionAction">The action that'll get invoked when menu option is clicked.</param>
        /// <returns></returns>
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