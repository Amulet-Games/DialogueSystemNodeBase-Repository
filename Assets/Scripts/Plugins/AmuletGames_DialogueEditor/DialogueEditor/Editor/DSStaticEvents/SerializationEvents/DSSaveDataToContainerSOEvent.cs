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
        public static void Clear()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register actions from different modules to the event.
        /// </summary>
        /// <param name="serializeHandler">Dialogue system's serialize handler module.</param>
        public static void Register(DSSerializeHandler serializeHandler)
        {
            mEvent += serializeHandler.SaveEdgesAndNodesAction;
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