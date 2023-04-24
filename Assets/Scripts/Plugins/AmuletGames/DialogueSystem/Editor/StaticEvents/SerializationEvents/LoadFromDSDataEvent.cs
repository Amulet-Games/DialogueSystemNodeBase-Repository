using System;

namespace AG.DS
{
    public class LoadFromDSDataEvent
    {
        /// <summary>
        /// LoadFromDSDataEvent, which'll be invoked automatically when the editor window is first opened
        /// <br>or manually by user clicking the load button on the editor's headBar.</br>
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
        /// <param name="eventPara">The scriptable object asset parameter that is needed for this event to be invoked.</param>
        public static void Invoke(DialogueSystemData eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}