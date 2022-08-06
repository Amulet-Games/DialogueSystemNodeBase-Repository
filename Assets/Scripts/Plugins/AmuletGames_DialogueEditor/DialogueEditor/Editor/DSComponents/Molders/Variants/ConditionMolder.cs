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
        /// <summary>
        /// Ask DSModifierMaker to create a new instance condition modifier for the molder.
        /// </summary>
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