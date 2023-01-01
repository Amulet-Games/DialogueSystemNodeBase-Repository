using System;

namespace AG.DS
{
    [Serializable]
    public class UnmetOptionDisplayTypeEnumContainer : EnumContainerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the unmet option display type enum container component class.
        /// </summary>
        public UnmetOptionDisplayTypeEnumContainer()
        {
            Value = (int)S_Condition_UnmetOptionDisplayType.Hide;
        }


        // ----------------------------- Init Field Value Services -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((S_Condition_UnmetOptionDisplayType)Value);


        // ----------------------------- Update Field Value Services -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((S_Condition_UnmetOptionDisplayType)Value);
    }
}