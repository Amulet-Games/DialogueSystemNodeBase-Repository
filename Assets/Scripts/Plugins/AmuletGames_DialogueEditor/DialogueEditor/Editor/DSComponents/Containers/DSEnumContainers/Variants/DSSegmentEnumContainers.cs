using System;

namespace AG
{
    [Serializable]
    public class UnmetOptionDisplayTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of unmet option display type enum container.
        /// </summary>
        public UnmetOptionDisplayTypeEnumContainer()
        {
            Value = (int)S_Condition_UnmetOptionDisplayType.Hide;
        }


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void SetFieldValueNonAlert(int newValue)
            =>
            EnumField.SetValueWithoutNotify((S_Condition_UnmetOptionDisplayType)newValue);


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
            =>
            EnumField.Init((S_Condition_UnmetOptionDisplayType)Value);
    }


    [Serializable]
    public class TextlineNumberTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of textline number type enum container.
        /// </summary>
        public TextlineNumberTypeEnumContainer()
        {
            Value = (int)S_Dialogue_TextlineNumberType.Single;
        }


        // ----------------------------- Compare Enum's Value Services -----------------------------
        /// <summary>
        /// Returns true if the enum container's value is equal to "Single". 
        /// </summary>
        /// <returns>True if the enum container's value is equal to "Single"</returns>
        public bool IsSingleTextlineNumberType()
            =>
            (S_Dialogue_TextlineNumberType)Value == S_Dialogue_TextlineNumberType.Single;


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void SetFieldValueNonAlert(int newValue)
            =>
            EnumField.SetValueWithoutNotify((S_Dialogue_TextlineNumberType)newValue);


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
            =>
            EnumField.Init((S_Dialogue_TextlineNumberType)Value);
    }


    [Serializable]
    public class SecondLineTriggerTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of second line trigger type enum container.
        /// </summary>
        public SecondLineTriggerTypeEnumContainer()
        {
            Value = (int)S_Dialogue_SecondLineTriggerType.DeltaTime;
        }


        // ----------------------------- Compare Enum's Value Services -----------------------------
        /// <summary>
        /// Returns true if the enum container's value is equal to "Input". 
        /// </summary>
        /// <returns>True if the enum container's value is equal to "Input"</returns>
        public bool IsInputTriggerType()
            =>
            (S_Dialogue_SecondLineTriggerType)Value == S_Dialogue_SecondLineTriggerType.Input;


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void SetFieldValueNonAlert(int newValue)
            =>
            EnumField.SetValueWithoutNotify((S_Dialogue_SecondLineTriggerType)newValue);


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
            =>
            EnumField.Init((S_Dialogue_SecondLineTriggerType)Value);
    }
}