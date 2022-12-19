using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the enum field is assigned to a new value,
        /// <br>the Value(int) in the enum container will changed at the sametime.</br>
        /// </summary>
        /// <param name="enumContainer">The container of which the field is connecting to.</param>
        /// <param name="containerValueChangedAction">The action to invoke when the container's value is changed.</param>
        public static void RegisterValueChangedEvent
        (
            EnumContainerBase enumContainer,
            Action containerValueChangedAction = null
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

                // Invoke containerValueChangedAction.
                containerValueChangedAction?.Invoke();

                // Set unsaved changes to true.
                InvokeWindowChangedEvent();
            });
        }
    }
}