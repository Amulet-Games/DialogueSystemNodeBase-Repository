using System;

namespace AG.DS
{
    [Serializable]
    public class SecondLineTriggerTypeEnumContainer : EnumContainerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the second line trigger type enum container component class.
        /// </summary>
        public SecondLineTriggerTypeEnumContainer()
        {
            Value = (int)S_Dialogue_SecondLineTriggerType.DeltaTime;
        }


        // ----------------------------- Init Field Value Services -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((S_Dialogue_SecondLineTriggerType)Value);


        // ----------------------------- Update Field Value Services -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((S_Dialogue_SecondLineTriggerType)Value);


        // ----------------------------- Compare Enum's Value Services -----------------------------
        /// <summary>
        /// Returns true if the enum container's value is equal to "Input". 
        /// </summary>
        /// <returns>True if the enum container's value is equal to "Input"</returns>
        public bool IsInputTriggerType() =>
            (S_Dialogue_SecondLineTriggerType)Value == S_Dialogue_SecondLineTriggerType.Input;
    }
}