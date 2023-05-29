using System;

namespace AG.DS
{
    public class LoadFromDSDataEvent
    {
        /// <summary>
        /// The event to invoke when the dialogue editor window is first opened,
        /// <br>or when the user clicked the load button in the headBar element.</br>
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