using System;

namespace AG.DS
{
    [Serializable]
    public class EventMolder : MolderFrameBase
    <
        EventModifier,
        EventModifierData,
        EventSegment,
        EventSegmentData,
        EventMolderData
    >
    {
        // ----------------------------- Add Modifier Services -----------------------------
        /// <inheritdoc />
        protected override void AddInstanceModifier()
        {
            new EventModifier().CreateInstanceElements
            (
                data: null,
                modifierCreatedAction: ModifierCreatedAction,
                removeButtonClickAction: ModifierRemoveButtonClickAction
            );
        }
    }
}