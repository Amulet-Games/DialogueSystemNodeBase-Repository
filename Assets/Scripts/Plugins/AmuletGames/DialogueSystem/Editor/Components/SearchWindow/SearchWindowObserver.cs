using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class SearchWindowObserver
    {
        /// <summary>
        /// The targeting search window component.
        /// </summary>
        SearchWindow searchWindow;


        /// <summary>
        /// The event to invoke when an entry in the search window is selected.
        /// </summary>
        Func<SearchTreeEntry, SearchWindowContext, bool> entrySelectedEvent;


        /// <summary>
        /// Constructor of the search window observer class.
        /// </summary>
        /// <param name="searchWindow">The search window to set for.</param>
        /// <param name="entrySelectedEvent">The EntrySelectedEvent to set for.</param>
        public SearchWindowObserver
        (
            SearchWindow searchWindow,
            Func<SearchTreeEntry, SearchWindowContext, bool> entrySelectedEvent
        )
        {
            this.searchWindow = searchWindow;
            this.entrySelectedEvent = entrySelectedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the search window component.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEntrySelectEvent();
        }


        /// <summary>
        /// Register EntrySelectedEvent to the search window.
        /// </summary>
        void RegisterEntrySelectEvent() => searchWindow.EntrySelectedEvent = entrySelectedEvent;
    }
}