using System;

namespace AG.DS
{
    public static class WindowChangedEvent
    {
        /// <summary>
        /// The event to invoke when there are new changes happened to the dialogue system window.
        /// </summary>
        static event Action m_Event;


        /// <summary>
        /// Register the given action to the event.
        /// </summary>
        /// <param name="action">The action to register for.</param>
        public static void Register(Action action)
        {
            m_Event += action;
        }


        /// <summary>
        /// Unregister the given action from the event.
        /// </summary>
        /// <param name="action">The action to unregister for.</param>
        public static void Unregister(Action action)
        {
            m_Event -= action;
        }


        /// <summary>
        /// Invoke event.
        /// </summary>
        public static void Invoke()
        {
            m_Event.Invoke();
        }
    }
}