using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class SearchWindowObserver
    {
        /// <summary>
        /// The targeting search window base component.
        /// </summary>
        SearchWindowBase searchWindow;


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
            SearchWindowBase searchWindow,
            Func<SearchTreeEntry, SearchWindowContext, bool> entrySelectedEvent
        )
        {
            this.searchWindow = searchWindow;
            this.entrySelectedEvent = entrySelectedEvent;
        }


        // ----------------------------- Register Events -----------------------------
        public void RegisterEvents()
        {
            RegisterEntrySelectEvent();
        }


        /// <summary>
        /// Register EntrySelectedEvent to the search window.
        /// </summary>
        void RegisterEntrySelectEvent() =>
            searchWindow.EntrySelectedEvent += SearchWindowEntrySelectedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when an entry in the search window is selected.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        bool SearchWindowEntrySelectedEvent(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            return entrySelectedEvent.Invoke(searchTreeEntry, context);
        }
    }
}