using System.Collections.Generic;

namespace AG.DS
{
    public class LanguageHandler
    {
        /// <summary>
        /// Reference of the language handler callback.
        /// </summary>
        LanguageHandlerCallback callback;


        /// <summary>
        /// Cache of the language field views that on the graph.
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
                callback.OnLanguageChange();
            }
        }


        /// <summary>
        /// The current language type of the dialogue system window.
        /// </summary>
        LanguageType m_CurrentLanguage;


        /// <summary>
        /// Constructor of the language handler class.
        /// </summary>
        public LanguageHandler()
        {
            callback = new(languageHandler: this);

            LanguageFieldViews = new();
            CurrentLanguage = LanguageType.English;
        }


        // ----------------------------- Services -----------------------------
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