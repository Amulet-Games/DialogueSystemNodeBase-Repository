using System;

namespace AG.DS
{
    public class SaveToDSDataEvent
    {
        /// <summary>
        /// The event to invoke when the user clicked the save button in the headBar element.
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
        /// Register the given action to the event.
        /// </summary>
        /// <param name="action">The action to register with.</param>
        public static void Register(Action<DialogueSystemData> action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        /// <param name="dsData">The dialogue system data to invoke with.</param>
        public static void Invoke(DialogueSystemData dsData)
        {
            mEvent?.Invoke(dsData);
        }
    }
}