using System;

namespace AG.DS
{
    [Serializable]
    public class TextlineNumberTypeEnumContainer : EnumContainerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the textline number type enum container class.
        /// </summary>
        public TextlineNumberTypeEnumContainer()
        {
            Value = (int)S_Dialogue_TextlineNumberType.Single;
        }


        // ----------------------------- Init Field Value Services -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((S_Dialogue_TextlineNumberType)Value);


        // ----------------------------- Update Field Value Services -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((S_Dialogue_TextlineNumberType)Value);


        // ----------------------------- Compare Enum's Value Services -----------------------------
        /// <summary>
        /// Returns true if the enum container's value is equal to "Single". 
        /// </summary>
        /// <returns>True if the enum container's value is equal to "Single"</returns>
        public bool IsSingleTextlineNumberType() =>
            (S_Dialogue_TextlineNumberType)Value == S_Dialogue_TextlineNumberType.Single;
    }
}