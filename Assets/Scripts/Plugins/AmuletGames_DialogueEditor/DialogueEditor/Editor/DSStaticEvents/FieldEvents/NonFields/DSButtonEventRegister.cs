using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSButtonEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Register a new clicked action for button element.
        /// <br>Each time the button is clicked, DSWindowChangedEvent will get invoked as well.</br>
        /// </summary>
        /// <typeparam name="T">Type has no constrain.</typeparam>
        /// <param name="button">The button of which the clicked action is assigned to.</param>
        /// <param name="buttonClickedAction">The action that'll be invoked when button is clicked.</param>
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
        /// Register a new clicked action for button element.
        /// <br>Each time button is clicked, DSWindowChangedEvent will get invoked as well.</br>
        /// </summary>
        /// <param name="button">The button of which the clicked action is assigned to.</param>
        /// <param name="buttonClickedAction">The action that'll be invoked when button is clicked.</param>
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