using System;

namespace AG
{
    public class DSTreeEntrySelectedEvent
    {
        /// <summary>
        /// DSTreeEntrySelectedEvent, which'll be invoked when a search entry is selected
        /// <br>in the search tree window by user.</br> 
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
        /// Invoke DSTreeEntrySelectedEvent.
        /// </summary>
        public static void Invoke()
        {
            Event?.Invoke();
        }
    }
}