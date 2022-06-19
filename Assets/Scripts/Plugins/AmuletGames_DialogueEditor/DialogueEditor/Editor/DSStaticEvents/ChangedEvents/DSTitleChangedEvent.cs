using System;

namespace AG
{
    public class DSTitleChangedEvent
    {
        public static event Action<string> mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.RenameContainerFromField;
        }

        /// Invoke.
        public static void Invoke(string eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}
