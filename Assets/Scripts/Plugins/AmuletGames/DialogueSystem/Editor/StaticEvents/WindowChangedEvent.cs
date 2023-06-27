using System;

namespace AG.DS
{
    public static class WindowChangedEvent
    {
        /// <summary>
        /// The event to invoke when there are new changes happened to the dialogue editor window.
        /// </summary>
        static event Action mEvent;


        /// <summary>
        /// Register the given action to the event.
        /// </summary>
        /// <param name="action">The action to register with.</param>
        public static void Register(Action action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Unregister the given action from the event.
        /// </summary>
        /// <param name="action">The action to unregister with.</param>
        public static void Unregister(Action action)
        {
            mEvent -= action;
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