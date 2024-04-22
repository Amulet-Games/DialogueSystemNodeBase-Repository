using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    public class SelectorSearchWindowView
    {
        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SearchWindow SearchWindow;


        /// <summary>
        /// The event to invoke to get the search window's search tree entries.
        /// </summary>
        public Func<List<SearchTreeEntry>> GetSearchTreeEntriesEvent;


        /// <summary>
        /// The event to invoke to get the search window's open position.
        /// </summary>
        public Func<Rect> GetWindowOpenPositionEvent;


        /// <summary>
        /// Constructor of the selector search window view.
        /// </summary>
        /// <param name="searchWindow">The search window to set for.</param>
        public SelectorSearchWindowView(SearchWindow searchWindow)
        {
            SearchWindow = searchWindow;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Open the search window.
        /// </summary>
        public void OpenWindow()
        {
            SearchWindow.SearchTreeEntries = GetSearchTreeEntriesEvent.Invoke();
            
            var position = GetWindowOpenPositionEvent.Invoke();
            SearchWindow.OpenWindow
            (
                screenMousePosition: position.position,
                requestWidth: position.size.x,
                requestHeight: position.size.y
            );
        }
    }
}