using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class MessageModifier
        : ModifierFrameBase<MessageModifier, MessageModifierData>
    {
        /// <inheritdoc />
        public override void CreateInstanceElements
        (
            MessageModifierData data,
            Action<MessageModifier> modifierCreatedAction,
            Action<MessageModifier> removeButtonClickAction
        )
        {
            /// Do something...
        }
    }
}