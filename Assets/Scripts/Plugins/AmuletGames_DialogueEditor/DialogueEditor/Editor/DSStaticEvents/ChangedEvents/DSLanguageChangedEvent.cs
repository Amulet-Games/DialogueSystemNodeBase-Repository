using System;

namespace AG
{
    public class DSLanguageChangedEvent
    {
        /// <summary>
        /// DSLanguageChangedEvent, which'll be invoked when the editor window's
        /// <br>language is changed to a new one.</br>
        /// </summary>
        static event Action mEvent;


        /// <summary>
        /// Clear all the actions that have registered to the DSLanguageChangedEvent.
        /// </summary>
        public static void Clear()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register the action to DSLanguageChangedEvent.
        /// </summary>
        /// <param name="action">The action to add to the event.</param>
        public static void Register(Action action)
        {
            mEvent += action;
        }


        /// <summary>
        /// Remove the action that has been registered from the DSLanguageChangedEvent.
        /// </summary>
        /// <param name="action">The action to remove from the event.</param>
        public static void UnRegister(Action action)
        {
            mEvent -= action;
        }


        /// <summary>
        /// Invoke the DSLanguageChangedEvent.
        /// </summary>
        public static void Invoke()
        {
            mEvent?.Invoke();
        }
    }
}