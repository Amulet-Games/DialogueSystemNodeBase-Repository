namespace AG.DS
{
    public class LanguageHandlerObserver
    {
        /// <summary>
        /// The targeting language handler module.
        /// </summary>
        LanguageHandler handler;


        /// <summary>
        /// Constructor of the language handler observer class.
        /// </summary>
        /// <param name="handler">The language handler module to set for.</param>
        public LanguageHandlerObserver(LanguageHandler handler)
        {
            this.handler = handler;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the language handler module.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterCurrentLanguageChangedEvent();
        }


        /// <summary>
        /// Register CurrentLanguageChangedEvent to the language handler module.
        /// </summary>
        void RegisterCurrentLanguageChangedEvent()
            => handler.CurrentLanguageChangedEvent = CurrentLanguageChangedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the current language of the language handler has changed.
        /// </summary>
        void CurrentLanguageChangedEvent()
        {
            var views = handler.LanguageFieldViews;
            var count = views.Count;

            for (int i = 0; i < count; i++)
            {
                views[i].UpdateFieldLanguageValue();
            }
        }
    }
}