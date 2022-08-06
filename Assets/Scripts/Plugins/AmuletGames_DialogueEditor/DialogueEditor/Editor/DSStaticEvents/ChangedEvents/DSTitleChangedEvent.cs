using System;

namespace AG
{
    public class DSTitleChangedEvent
    {
        /// <summary>
        /// DSTitleChangedEvent, which'll be invoked when the graph's title is changed to a new one
        /// <br>through unity project window.</br>
        /// </summary>
        static event Action<string> mEvent;


        /// <summary>
        /// Clear all the actions that have been registered to the event.
        /// </summary>
        public static void ClearEvents()
        {
            mEvent = null;
        }


        /// <summary>
        /// Register actions from different modules to the event.
        /// </summary>
        public static void RegisterEvent()
        {
            mEvent += DialogueEditorWindow.TitleTextFieldChangedAction;
        }


        /// <summary>
        /// Invoke DSTitleChangedEvent.
        /// </summary>
        /// <param name="eventPara">The string parameter that is needed for this event to be invoked.</param>
        public static void Invoke(string eventPara)
        {
            mEvent?.Invoke(eventPara);
        }
    }
}
