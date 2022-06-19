using System;

namespace AG
{
    public static class DSWindowChangedEvent
    {
        /// Called for each time when a visual element field's value has been changed.
        
        public static event Action mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.SetHasUnsavedChangesToTrue;
        }

        public static void MultiCastEvents()
        {
            DSGraphViewChangedEvent.mEvent += mEvent;
            DSTreeEntrySelectedEvent.mEvent += mEvent;
        }
        
        /// Invoke.
        public static void Invoke()
        {
            if (!DialogueEditorWindow.dsWindow.hasUnsavedChanges)
            {
                mEvent.Invoke();
            }
        }
    }
}