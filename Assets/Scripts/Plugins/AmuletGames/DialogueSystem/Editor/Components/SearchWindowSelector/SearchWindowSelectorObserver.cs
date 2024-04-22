using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class SearchWindowSelectorObserver
    {
        /// <summary>
        /// The targeting search window selector element.
        /// </summary>
        SearchWindowSelector selector;


        /// <summary>
        /// The event to invoke when selected entry has changed.
        /// </summary>
        Action<SearchTreeEntry> selectedEntryChangedEvent;


        /// <summary>
        /// The event to invoke to get the search window's search tree entries.
        /// </summary>
        Func<List<SearchTreeEntry>> getSearchTreeEntriesEvent;


        /// <summary>
        /// Constructor of the search window selector observer class.
        /// </summary>
        /// <param name="selector">The search window selector to set for.</param>
        /// <param name="selectedEntryChangedEvent">The SelectedEntryChangedEvent to set for.</param>
        /// <param name="getSearchTreeEntriesEvent">The GetSearchTreeEntriesEvent to set for.</param>
        public SearchWindowSelectorObserver
        (
            SearchWindowSelector selector,
            Action<SearchTreeEntry> selectedEntryChangedEvent,
            Func<List<SearchTreeEntry>> getSearchTreeEntriesEvent
        )
        {
            this.selector = selector;
            this.selectedEntryChangedEvent = selectedEntryChangedEvent;
            this.getSearchTreeEntriesEvent = getSearchTreeEntriesEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge connector search window.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterSelectorButtonMouseDownEvent();

            RegisterSelectedEntryChangedEvent();

            RegisterSelectorSearchWindowViewEvents();

            RegisterSelectorSearchWindowEntrySelectedEvent();
        }


        /// <summary>
        /// Register SelectorButtonMouseDownEvent to the selector button.
        /// </summary>
        void RegisterSelectorButtonMouseDownEvent() =>
            selector.SelectorButton.RegisterCallback<MouseDownEvent>(SelectorButtonMouseDownEvent);


        /// <summary>
        /// Register SelectedEntryChangedEvent to the selector.
        /// </summary>
        void RegisterSelectedEntryChangedEvent() =>
            selector.SelectedEntryChangedEvent += selectedEntryChangedEvent;


        /// <summary>
        /// Register events to the selector search window view.
        /// </summary>
        void RegisterSelectorSearchWindowViewEvents()
            => new SelectorSearchWindowObserver(
                view: selector.SelectorSearchWindowView,
                getSearchTreeEntriesEvent: getSearchTreeEntriesEvent,
                getWindowOpenPositionEvent: () => selector.GetWindowOpenPosition()).RegisterEvents();


        /// <summary>
        /// Register EntrySelectedEvent to the selector search window.
        /// </summary>
        void RegisterSelectorSearchWindowEntrySelectedEvent()
            => new SearchWindowObserver(
                searchWindow: selector.SelectorSearchWindowView.SearchWindow,
                entrySelectedEvent: SelectorSearchWindowEntrySelectedEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the search window selector button element.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void SelectorButtonMouseDownEvent(MouseDownEvent evt)
        {
            RegisterSelectorSearchWindowEntrySelectedEvent();

            selector.SelectorSearchWindowView.OpenWindow();

            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }


        /// <summary>
        /// The event to invoke when an entry in the selector search window is selected.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        bool SelectorSearchWindowEntrySelectedEvent(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            selector.SelectedEntry = searchTreeEntry;
            
            return true;
        }
    }
}