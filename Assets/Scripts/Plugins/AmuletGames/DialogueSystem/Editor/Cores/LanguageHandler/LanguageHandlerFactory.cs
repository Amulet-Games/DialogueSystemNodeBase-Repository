namespace AG.DS
{
    public class LanguageHandlerFactory
    {
        /// <summary>
        /// Generate a new language handler module.
        /// </summary>
        /// <returns>A new language handler module.</returns>
        public static LanguageHandler Generate()
        {
            var handler = new LanguageHandler();

            new LanguageHandlerObserver(handler).RegisterEvents();

            return handler;
        }
    }
}