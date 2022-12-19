using System;

namespace AG.DS
{
    public class GraphViewChangedEvent
    {
        /// <summary>
        /// GraphViewChangedEvent, which'll be invoked when the user has made any changes on the graph.
        /// </summary>
        public static event Action Event;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void Clear()
        {
            Event = null;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            Event?.Invoke();
        }
    }
}