using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class IconicEnumFieldCallbacks
    {
        /// <summary>
        /// Register value changed actions to the given container's field element.
        /// </summary>
        /// <param name="iconicEnumContainer">The container that connects with the field that the value changed actions are assigning to.</param>
        /// <param name="additionalValueChangedAction">The additional action to assign with, it's optional.</param>
        public static void RegisterValueChangedEvent
        (
            IconicEnumFieldViewBase iconicEnumContainer,
            Action additionalValueChangedAction = null
        )
        {
            iconicEnumContainer.EnumField.RegisterValueChangedCallback(callback =>
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(
                //    reversible: iconicEnumContainer,
                //    dataReversedAction: containerValueChangedAction
                //);

                iconicEnumContainer.Value = (int)(object)callback.newValue;
                iconicEnumContainer.UpdateIconImage();

                additionalValueChangedAction?.Invoke();
                WindowChangedEvent.Invoke();
            });
        }
    }
}