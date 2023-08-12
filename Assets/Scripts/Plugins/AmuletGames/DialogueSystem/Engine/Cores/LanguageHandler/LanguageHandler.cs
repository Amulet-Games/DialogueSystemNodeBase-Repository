using System.Collections.Generic;

namespace AG.DS
{
    public class LanguageHandler
    {
        /// <summary>
        /// The property of the current language type of the dialogue editor window.
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
        /// The current language type of the dialogue editor window.
        /// </summary>
        LanguageType m_CurrentLanguage;


        /// <summary>
        /// Cache of the language field views on the graph.
        /// </summary>
        public List<ILanguageFieldView> LanguageFieldViews;


        /// <summary>
        /// The language field views cache counter.
        /// </summary>
        public int LanguageFieldViewsCount { get; private set; } = 0;


        /// <summary>
        /// Reference of the language handler callback.
        /// </summary>
        LanguageHandlerCallback callback;


        /// <summary>
        /// Constructor of the language handler class.
        /// </summary>
        public LanguageHandler()
        {
            callback = new(languageHandler: this);

            CurrentLanguage = LanguageType.English;
            LanguageFieldViews = new();
        }


        // ----------------------------- Serialization -----------------------------
        public void Save()
        {

        }


        public void Load()
        {

        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Remove the language field view from the internal cache.
        /// </summary>
        /// <param name="view"></param>
        public void Remove(ILanguageFieldView view)
        {
            LanguageFieldViews.Remove(view);
            LanguageFieldViewsCount--;
        }


        /// <summary>
        /// Add the language field view to the internal cache.
        /// </summary>
        /// <param name="view"></param>
        public void Add(ILanguageFieldView view)
        {
            LanguageFieldViews.Add(view);
            LanguageFieldViewsCount++;
        }
    }
}