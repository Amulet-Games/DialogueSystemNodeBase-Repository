using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        /// <param name="enumContainer">The container that connects with the field that the value changed actions are assigning to.</param>
        /// <param name="additionalValueChangedAction">The additional action to assign with, it's optional.</param>
        public static void RegisterValueChangedEvent
        (
            EnumFieldModelBase enumContainer,
            Action additionalValueChangedAction = null
        )
        {
            enumContainer.EnumField.RegisterValueChangedCallback(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(
                //    reversible: enumContainer,
                //    dataReversedAction: containerValueChangedAction
                //);

                // Set the new value to the container.
                enumContainer.Value = (int)(object)callback.newValue;

                // Invoke additional value changed action.
                additionalValueChangedAction?.Invoke();

                // Set unsaved changes to true.
                WindowChangedEvent.Invoke();
            });
        }
    }
}