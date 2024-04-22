using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class SearchWindowSelector : VisualElement
    {
        /// <summary>
        /// The property of the selected search tree entry.
        /// </summary>
        public SearchTreeEntry SelectedEntry
        {
            get
            {
                return m_selectedEntry;
            }
            set
            {
                if (value == m_selectedEntry)
                {
                    return;
                }

                m_selectedEntry = value;

                IsSelectedEntryNullValue = m_selectedEntry.userData == null;

                this.ToggleNullValueStyle();

                SelectedEntryChangedEvent?.Invoke(m_selectedEntry);
            }
        }


        /// <summary>
        /// The selected search tree entry.
        /// </summary>
        SearchTreeEntry m_selectedEntry;


        /// <summary>
        /// 
        /// </summary>
        public bool IsSelectedEntryNullValue;


        /// <summary>
        /// The text for the selector button label when the selected entry's user data is null.
        /// </summary>
        public string NullValueSelectorButtonLabelText;


        /// <summary>
        /// Image for the selector button icon.
        /// </summary>
        public Image SelectorButtonIconImage;


        /// <summary>
        /// Label for the selector button text.
        /// </summary>
        public Label SelectorButtonTextLabel;


        /// <summary>
        /// Button that shows the search window when clicked.
        /// </summary>
        public Button SelectorButton;


        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SelectorSearchWindowView SelectorSearchWindowView { get; private set; }


        /// <summary>
        /// The search window width.
        /// </summary>
        float searchWindowWidth;


        /// <summary>
        /// The search window height.
        /// </summary>
        float searchWindowHeight;


        /// <summary>
        /// The event to invoke when selected entry has changed.
        /// </summary>
        public Action<SearchTreeEntry> SelectedEntryChangedEvent;


        /// <summary>
        /// Constructor of the search window selector element.
        /// </summary>
        /// <param name="nullValueSelectorButtonLabelText">The null value selector button label text to set for.</param>
        /// <param name="searchWindowWidth">The search window width to set for.</param>
        /// <param name="searchWindowHeight">The search window height to set for.</param>
        /// <param name="selectorSearchWindowView">The selector search window view to set for.</param>
        public SearchWindowSelector
        (
            string nullValueSelectorButtonLabelText,
            float searchWindowWidth,
            float searchWindowHeight,
            SelectorSearchWindowView selectorSearchWindowView
        )
        {
            NullValueSelectorButtonLabelText = nullValueSelectorButtonLabelText;
            this.searchWindowWidth = searchWindowWidth;
            this.searchWindowHeight = searchWindowHeight;
            SelectorSearchWindowView = selectorSearchWindowView;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Returns the search window open position.
        /// </summary>
        /// <returns>The search window open position.</returns>
        public Rect GetWindowOpenPosition()
        {
            return new Rect(
                position: GUIUtility.GUIToScreenPoint(Event.current.mousePosition),
                size: new Vector2(searchWindowWidth, searchWindowHeight)
            );
        }
    }
}