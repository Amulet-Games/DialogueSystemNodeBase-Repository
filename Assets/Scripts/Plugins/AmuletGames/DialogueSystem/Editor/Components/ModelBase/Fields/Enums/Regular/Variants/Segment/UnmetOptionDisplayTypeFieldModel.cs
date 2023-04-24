using System;

namespace AG.DS
{
    [Serializable]
    public class UnmetOptionDisplayTypeEnumFieldModel : EnumFieldModelBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the unmet option display type enum field model class.
        /// </summary>
        public UnmetOptionDisplayTypeEnumFieldModel()
        {
            Value = (int)S_Condition_UnmetOptionDisplayType.Hide;
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((S_Condition_UnmetOptionDisplayType)Value);


        // ----------------------------- Update Field Value -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((S_Condition_UnmetOptionDisplayType)Value);
    }
}