using System;

namespace AG.DS
{
    [Serializable]
    public class MessageProgressTypeEnumFieldModel : EnumFieldModelBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the message progress type enum field model class.
        /// </summary>
        public MessageProgressTypeEnumFieldModel()
        {
            Value = (int)M_Message_ProgressType.Duration;
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((M_Message_ProgressType)Value);


        // ----------------------------- Update Field Value -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((M_Message_ProgressType)Value);


        // ----------------------------- Compare Enum's Value -----------------------------
        /// <summary>
        /// Returns true if the model's value is equal to "Duration". 
        /// </summary>
        /// <returns>True if the model's value is equal to "Duration"</returns>
        public bool IsDurationProgressType() =>
            (M_Message_ProgressType)Value == M_Message_ProgressType.Duration;
    }
}