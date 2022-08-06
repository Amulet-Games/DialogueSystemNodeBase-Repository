using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSBoxEventRegister : DSFieldEventRegisterBase
    {
        /// <summary>
        /// Register a new MouseDownEvent to the box element so that it works like a button,
        /// <br>and invoked DSWindowChangedEvent afterward.</br>
        /// </summary>
        /// <param name="box">The box of which the mouse down event is assigned to.</param>
        /// <param name="boxClickedAction">The action that'll be invoked when the box is clicked.</param>
        public static void DSBoxClickedAction(Box box, Action boxClickedAction)
        {
            box.RegisterCallback<MouseDownEvent>(_ =>
            {
                boxClickedAction.Invoke();

                InvokeDSWindowChangedEvent();
            });
        }
    }
}