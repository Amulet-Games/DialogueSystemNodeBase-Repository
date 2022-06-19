using System;

namespace AG
{
    public class DSSaveDataToContainerSOEvent
    {
        public static event Action<DialogueContainerSO> mEvent;

        /// Setup.
        public static void ClearEvents()
        {
            mEvent = null;
        }

        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.dsWindow.serializeHandler.SaveEdgesAndNodes;
        }

        /// Invoke.
        public static void Invoke(DialogueContainerSO eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}