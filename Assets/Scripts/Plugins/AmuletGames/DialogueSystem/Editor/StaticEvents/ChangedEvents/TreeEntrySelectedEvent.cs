using System;

namespace AG.DS
{
    public class TreeEntrySelectedEvent
    {
        /// <summary>
        /// TreeEntrySelectedEvent, which'll be invoked when a search entry is selected in the search
        /// <br>tree window by user.</br> 
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