using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class BoxCallbacks
    {
        /// <summary>
        /// Register new mouse down actions to the given box element.
        /// <para></para>
        /// When the mouse down actions are invoked, <see cref="WindowChangedEvent"/> will be invoked along side.
        /// <param name="box">The box of which the mouse down event is assigned to.</param>
        /// <param name="clickAction">The action to invoke when the box is clicked.</param>
        public static void RegisterMouseDownEvent
        (
            Box box,
            Action clickAction
        )
        {
            box.RegisterCallback<MouseDownEvent>(callback =>
            {
                callback.StopImmediatePropagation();

                clickAction.Invoke();

                WindowChangedEvent.Invoke();
            });
        }
    }
}