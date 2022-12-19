using System;

namespace AG.DS
{
    public class LanguageChangedEvent
    {
        /// <summary>
        /// LanguageChangedEvent, which'll be invoked when the editor window's language is changed
        /// <br>to a new one.</br>
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
        /// <param name="action">The action to add to the event.</param>
        public static void Register(Action action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Remove the given action that has been registered from the event.
        /// </summary>
        /// <param name="action">The action to remove from the event.</param>
        public static void UnRegister(Action action)
        {
            mEvent -= action;
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