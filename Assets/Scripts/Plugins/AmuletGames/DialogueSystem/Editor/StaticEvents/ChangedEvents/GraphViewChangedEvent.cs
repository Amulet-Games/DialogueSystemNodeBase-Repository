using System;

namespace AG.DS
{
    public class GraphViewChangedEvent
    {
        /// <summary>
        /// The event to invoke when certain changes have occurred in the graph.
        /// </summary>
        static event Action mEvent;


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
        public static void Register(Action action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}