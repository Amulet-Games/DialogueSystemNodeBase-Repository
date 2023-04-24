using System;

namespace AG.DS
{
    public static class WindowChangedEvent
    {
        /// <summary>
        /// WindowChangedEvent, which'll be invoked if any of the visual element field's value have been changed.
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
            mEvent.Invoke();
        }
    }
}