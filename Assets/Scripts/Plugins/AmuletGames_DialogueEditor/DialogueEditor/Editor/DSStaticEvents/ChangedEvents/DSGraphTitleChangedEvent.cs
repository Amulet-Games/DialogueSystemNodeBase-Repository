using System;

namespace AG
{
    public class DSGraphTitleChangedEvent
    {
        /// <summary>
        /// DSGraphTitleChangedEvent, which'll be invoked when the graph's title is changed to a new one
        /// <br>through unity project window.</br>
        /// </summary>
        static event Action<string> mEvent;


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
        /// <param name="headBar">Dialogue system's Headbar module.</param>
        public static void Register(DSHeadBar headBar)
        {
            mEvent += headBar.GraphTitleFieldChangedAction;
        }


        /// <summary>
        /// Invoke DSGraphTitleChangedEvent.
        /// </summary>
        /// <param name="eventPara">The string parameter that is needed for this event to be invoked.</param>
        public static void Invoke(string eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}
