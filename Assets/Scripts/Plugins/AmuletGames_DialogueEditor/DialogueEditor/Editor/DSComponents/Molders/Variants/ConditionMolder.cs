using System;

namespace AG
{
    /// <summary>
    /// A special node's UI style that combined the use of segment, modifier and content button together.
    /// </summary>
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