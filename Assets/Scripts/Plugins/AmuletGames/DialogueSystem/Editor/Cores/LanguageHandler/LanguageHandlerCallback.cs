namespace AG.DS
{
    public class LanguageHandlerCallback
    {
        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        LanguageHandler languageHandler;


        /// <summary>
        /// Constructor of the language handler callback class.
        /// </summary>
        /// <param name="graphViewer">The language handler to set for.</param>
        public LanguageHandlerCallback(LanguageHandler languageHandler)
        {
            this.languageHandler = languageHandler;
        }


        /// <summary>
        /// The callback to invoke when the current language of the dialogue system window's is changed.
        /// </summary>
        public void OnLanguageChange()
        {
            var views = languageHandler.LanguageFieldViews;
            var count = views.Count;

            for (int i = 0; i < count; i++)
            {
                views[i].UpdateFieldLanguageValue();
            }
        }
    }
}