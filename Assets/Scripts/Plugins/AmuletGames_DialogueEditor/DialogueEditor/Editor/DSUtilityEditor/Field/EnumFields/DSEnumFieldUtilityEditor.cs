using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEnumFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the enum field is assigned to a new value,
        /// the Value(enum) in the enum container will changed at the sametime. 
        /// </summary>
        /// <param name="enumContainer">Enum container of which the enum field is connecting to.</param>
        public static void RegisterValueChangedEvent(EnumContainerBase enumContainer)
        {
            enumContainer.EnumField.RegisterValueChangedCallback(value =>
            {
                enumContainer.SetEnumValue(value.newValue);

                InvokeDSWindowChangedEvent();
            });
        }

        /// <summary>
        /// Each time the enum field is assigned to a new value,
        /// the Value(enum) in the enum container will changed at the sametime. 
        /// </summary>
        /// <param name="enumContainer">Enum container of which the enum field is connecting to.</param>
        /// <param name="fieldValueChangedAction">The action that get will invoked along side with.</param>
        public static void RegisterValueChangedEvent(EnumContainerBase enumContainer, Action fieldValueChangedAction)
        {
            enumContainer.EnumField.RegisterValueChangedCallback(value =>
            {
                enumContainer.SetEnumValue(value.newValue);

                fieldValueChangedAction.Invoke();

                InvokeDSWindowChangedEvent();
            });
        }
    }
}