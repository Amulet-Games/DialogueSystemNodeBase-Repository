using System;

namespace AG
{
    public class DSGraphViewChangedEvent
    {
        /// <summary>
        /// DSGraphViewChangedEvent, which'll be invoked when the user has made any changes on the graph.
        /// </summary>
        public static event Action Event;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void ClearEvents()
        {
            Event = null;
        }


        /// <summary>
        /// Invoke DSGraphViewChangedEvent.
        /// </summary>
        public static void Invoke()
        {
            Event?.Invoke();
        }
    }
}