using System;

namespace AG
{
    public class DSLoadDataFromContainerSOEvent
    {
        public static event Action<DialogueContainerSO> mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            DialogueEditorWindow _dsWindow = DialogueEditorWindow.dsWindow;

            mEvent += _dsWindow.serializeHandler.LoadEdgesAndNodes;
            mEvent += _dsWindow.headBar.LoadGraphLanguageAndTitle;
        }

        /// Invoke.
        public static void Invoke(DialogueContainerSO eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}