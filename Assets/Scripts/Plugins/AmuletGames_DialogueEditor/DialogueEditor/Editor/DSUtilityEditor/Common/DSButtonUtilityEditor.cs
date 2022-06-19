using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSButtonUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Register a new clicked action for button,
        /// each time when button is clicked DSWindowChangedEvent will be invoked as well.
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="button">The button of which the clicked action is assign to.</param>
        /// <param name="buttonClickedAction">The action that will be invoked when button is clicked.</param>
        /// <param name="actionPara">Parameter used in button clicked action.</param>
        public static void DSButtonClickedAction<T>(Button button, Action<T> buttonClickedAction, T actionPara)
        {
            button.clicked += () =>
            {
                buttonClickedAction.Invoke(actionPara);

                InvokeDSWindowChangedEvent();
            };
        }

        /// <summary>
        /// Register a new clicked action for button,
        /// each time when button is clicked DSWindowChangedEvent will be invoked as well.
        /// </summary>
        /// <param name="button">The button of which the clicked action is assign to.</param>
        /// <param name="buttonClickedAction">The action that will be invoked when button is clicked.</param>
        public static void DSButtonClickedAction(Button button, Action buttonClickedAction)
        {
            button.clicked += () =>
            {
                buttonClickedAction.Invoke();

                InvokeDSWindowChangedEvent();
            };
        }
    }
}