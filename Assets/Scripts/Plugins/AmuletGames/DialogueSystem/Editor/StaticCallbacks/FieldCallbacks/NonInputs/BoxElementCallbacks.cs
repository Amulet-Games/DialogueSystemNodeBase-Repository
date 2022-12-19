using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class BoxElementCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Register a new MouseDownEvent to the box element so that it works like a button,
        /// <br>and invoked WindowChangedEvent afterward.</br>
        /// </summary>
        /// <param name="box">The box of which the mouse down event is assigned to.</param>
        /// <param name="boxClickedAction">The action to invoke when the box is clicked.</param>
        public static void RegisterMouseDownEvent
        (
            Box box,
            Action boxClickedAction
        )
        {
            box.RegisterCallback<MouseDownEvent>(callback =>
            {
                callback.StopImmediatePropagation();

                boxClickedAction.Invoke();

                InvokeWindowChangedEvent();
            });
        }
    }
}