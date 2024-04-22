using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class SelectorSearchWindowObserver
    {
        /// <summary>
        /// The targeting selector search window view.
        /// </summary>
        SelectorSearchWindowView view;


        /// <summary>
        /// The event to invoke to get the search window's search tree entries.
        /// </summary>
        Func<List<SearchTreeEntry>> getSearchTreeEntriesEvent;


        /// <summary>
        /// The event to invoke to get the search window's open position.
        /// </summary>
        Func<Rect> getWindowOpenPositionEvent;


        /// <summary>
        /// Constructor of the selector search window observer class.
        /// </summary>
        /// <param name="view">The selector search window view to set for.</param>
        /// <param name="getSearchTreeEntriesEvent">The GetSearchTreeEntriesEvent to set for.</param>
        /// <param name="getWindowOpenPositionEvent">The GetWindowOpenPositionEvent to set for.</param>
        public SelectorSearchWindowObserver
        (
            SelectorSearchWindowView view,
            Func<List<SearchTreeEntry>> getSearchTreeEntriesEvent,
            Func<Rect> getWindowOpenPositionEvent
        )
        {
            this.view = view;
            this.getSearchTreeEntriesEvent = getSearchTreeEntriesEvent;
            this.getWindowOpenPositionEvent = getWindowOpenPositionEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the selector search window view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterGetSearchTreeEntriesEvent();

            RegisterGetWindowOpenPositionEvent();
        }


        /// <summary>
        /// Register GetWindowOpenPositionEvent to the view.
        /// </summary>
        void RegisterGetWindowOpenPositionEvent()
            => view.GetWindowOpenPositionEvent += getWindowOpenPositionEvent;


        /// <summary>
        /// Register GetSearchTreeEntriesEvent to the view.
        /// </summary>
        void RegisterGetSearchTreeEntriesEvent()
            => view.GetSearchTreeEntriesEvent += getSearchTreeEntriesEvent;
    }
}