using System;

namespace AG
{
    [Serializable]
    public class DialogueOverHandleTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of dialogue over handle type enum container.
        /// </summary>
        public DialogueOverHandleTypeEnumContainer()
        {
            Value = (int)N_End_DialogueOverHandleType.End;
        }


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void SetFieldValueNonAlert(int newValue)
            =>
            EnumField.SetValueWithoutNotify((N_End_DialogueOverHandleType)newValue);


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
            =>
            EnumField.Init((N_End_DialogueOverHandleType)Value);
    }
}