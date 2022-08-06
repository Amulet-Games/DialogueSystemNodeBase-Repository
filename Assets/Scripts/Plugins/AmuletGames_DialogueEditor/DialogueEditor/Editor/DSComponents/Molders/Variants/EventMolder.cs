using System;

namespace AG
{
    [Serializable]
    public class EventMolder : DSMolderBase<EventSegment, EventModifier>
    {
        /// <summary>
        /// Constructor of event molder.
        /// </summary>
        public EventMolder()
        {
            MolderRootModifier = new EventModifier();
            MolderSegment = new EventSegment();
        }


        // ----------------------------- Add Modifier Services -----------------------------
        /// <summary>
        /// Ask DSModifierMaker to create a new instance event modifier for the molder.
        /// </summary>
        protected override void AddInstanceModifier()
        {
            DSModifiersMaker.GetNewEventModifier
            (
                null,
                ModifierAddedAction,
                ModifierRemovedAction
            );
        }
    }
}