using System;

namespace AG
{
    public class DSSaveDataToContainerSOEvent
    {
        /// <summary>
        /// DSSaveDataToContainerSOEvent, which'll be invoked when user
        /// <br>clicked the save button on the editor's head bar.</br>
        /// </summary>
        static event Action<DialogueContainerSO> mEvent;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void ClearEvents()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register actions from different modules to the event.
        /// </summary>
        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.Instance.GraphView.SerializeHandler.SaveEdgesAndNodesAction;
        }


        /// <summary>
        /// Invoke DSSaveDataToContainerSOEvent.
        /// </summary>
        /// <param name="eventPara">The scriptable object asset parameter that is needed for this event to be invoked.</param>
        public static void Invoke(DialogueContainerSO eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}