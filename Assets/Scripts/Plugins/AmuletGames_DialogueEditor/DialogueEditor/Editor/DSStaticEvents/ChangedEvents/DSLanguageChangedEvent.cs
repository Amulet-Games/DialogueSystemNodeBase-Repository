using System;

namespace AG
{
    public class DSLanguageChangedEvent
    {
        public static event Action mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.dsWindow.graphView.ReloadLanguage;
        }

        /// Invoke.
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}