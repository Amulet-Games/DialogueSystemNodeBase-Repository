using System;

namespace AG.DS
{
    public class SaveToDSDataEvent
    {
        /// <summary>
        /// SaveToDSDataEvent, which'll be invoked when user clicked the save button
        /// <br>on the editor's headBar.</br>
        /// </summary>
        static event Action<DialogueSystemData> mEvent;


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
        public static void Register(SerializeHandler serializeHandler)
        {
            mEvent += serializeHandler.SaveEdgesAndNodesAction;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        /// <param name="eventPara">The scriptable object asset parameter that is needed for this event to be invoked.</param>
        public static void Invoke(DialogueSystemData eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}