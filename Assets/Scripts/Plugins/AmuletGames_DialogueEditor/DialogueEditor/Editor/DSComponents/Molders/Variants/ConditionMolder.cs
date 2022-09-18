using System;

namespace AG
{
    [Serializable]
    public class ConditionMolder : DSMolderBase<ConditionSegment, ConditionModifier>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition molder.
        /// </summary>
        public ConditionMolder()
        {
            MolderRootModifier = new ConditionModifier();
            MolderSegment = new ConditionSegment();
        }


        // ----------------------------- Add Modifier Services -----------------------------
        /// <inheritdoc />
        protected override void AddInstanceModifier()
        {
            DSModifiersMaker.GetNewConditionModifier
            (
                null,
                ModifierAddedAction,
                ModifierRemovedAction
            );
        }
    }
}