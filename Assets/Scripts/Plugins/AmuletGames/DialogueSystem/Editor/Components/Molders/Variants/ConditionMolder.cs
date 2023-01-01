using System;

namespace AG.DS
{
    /// <summary>
    /// A special node's UI style that combined the use of segment, modifier and content button together.
    /// </summary>
    [Serializable]
    public class ConditionMolder : MolderFrameBase
    <
        ConditionModifier,
        ConditionModifierData,
        ConditionSegment,
        ConditionSegmentData,
        ConditionMolderData
    >
    {
        // ----------------------------- Add Modifier Services -----------------------------
        /// <inheritdoc />
        protected override void AddInstanceModifier()
        {
            new ConditionModifier().CreateInstanceElements
            (
                data: null,
                modifierCreatedAction: ModifierCreatedAction,
                removeButtonClickAction: ModifierRemoveButtonClickAction
            );
        }
    }
}