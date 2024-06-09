using System;
using System.Collections.Generic;

namespace AG.DS
{
    public class LanguageHandler
    {
        /// <summary>
        /// The language field elements cache.
        /// </summary>
        public List<ILanguageFieldView> LanguageFieldViews { get; private set; }


        /// <summary>
        /// The property of the current language type of the dialogue system window.
        /// </summary>
        public LanguageType CurrentLanguage
        {
            get
            {
                return m_CurrentLanguage;
            }
            set
            {
                m_CurrentLanguage = value;

                CurrentLanguageChangedEvent?.Invoke();
            }
        }


        /// <summary>
        /// The current language type of the dialogue system window.
        /// </summary>
        LanguageType m_CurrentLanguage;


        /// <summary>
        /// The event to invoke when current language has changed.
        /// </summary>
        public Action CurrentLanguageChangedEvent;


        /// <summary>
        /// Constructor of the language handler class.
        /// </summary>
        public LanguageHandler()
        {
            LanguageFieldViews = new();
            CurrentLanguage = LanguageType.English;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Remove the language field view from the graph viewer's cache.
        /// </summary>
        /// <param name="view">The language field view to set for.</param>
        public void Remove(ILanguageFieldView view)
        {
            LanguageFieldViews.Remove(view);
        }


        /// <summary>
        /// Add the language field view to the graph viewer's cache.
        /// </summary>
        /// <param name="view">The language field view to set for.</param>
        public void Add(ILanguageFieldView view)
        {
            LanguageFieldViews.Add(view);
        }


        /// <summary>
        /// Clear the language field view cache.
        /// </summary>
        public void ClearCache()
        {
            LanguageFieldViews.Clear();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the handler values.
        /// </summary>
        public void Save()
        {

        }


        /// <summary>
        /// Load the handler values.
        /// </summary>
        public void Load()
        {

        }
    }
}