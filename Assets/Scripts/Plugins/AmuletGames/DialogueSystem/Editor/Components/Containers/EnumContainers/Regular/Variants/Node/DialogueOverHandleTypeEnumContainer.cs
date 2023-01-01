using System;

namespace AG.DS
{
    [Serializable]
    public class DialogueOverHandleTypeEnumContainer : EnumContainerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue over handle type enum container component class.
        /// </summary>
        public DialogueOverHandleTypeEnumContainer()
        {
            Value = (int)N_End_DialogueOverHandleType.End;
        }


        // ----------------------------- Init Field Value Services -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue() =>
            EnumField.Init((N_End_DialogueOverHandleType)Value);


        // ----------------------------- Update Field Value Services -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((N_End_DialogueOverHandleType)Value);
    }
}