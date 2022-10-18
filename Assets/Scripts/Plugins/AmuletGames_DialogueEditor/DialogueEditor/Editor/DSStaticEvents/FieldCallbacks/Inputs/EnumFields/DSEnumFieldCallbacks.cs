using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEnumFieldCallbacks : DSFieldCallbacksBase
    {
        /// <summary>
        /// Each time the enum field is assigned to a new value,
        /// <br>the Value(int) in the enum container will changed at the sametime.</br>
        /// </summary>
        /// <param name="enumContainer">The Enum container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent(EnumContainerBase enumContainer)
        {
            enumContainer.EnumField.RegisterValueChangedCallback(value =>
            {
                enumContainer.Value = (int)(object)value.newValue;

                InvokeDSWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time the enum field is assigned to a new value,
        /// <br>the Value(int) in the enum container will changed at the sametime.</br>
        /// </summary>
        /// <param name="enumContainer">The Enum container of which the field is connecting to.</param>
        /// <param name="fieldValueChangedAction">The action to invoke along side with.</param>
        public static void RegisterValueChangedEvent
        (
            EnumContainerBase enumContainer,
            Action fieldValueChangedAction
        )
        {
            enumContainer.EnumField.RegisterValueChangedCallback(value =>
            {
                enumContainer.Value = (int)(object)value.newValue;

                fieldValueChangedAction.Invoke();

                InvokeDSWindowChangedEvent();
            });
        }
    }
}