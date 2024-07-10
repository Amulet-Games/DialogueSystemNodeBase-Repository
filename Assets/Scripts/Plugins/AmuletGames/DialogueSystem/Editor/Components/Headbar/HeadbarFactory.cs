namespace AG.DS
{
    public class HeadbarFactory
    {
        /// <summary>
        /// Generate a new headbar element.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// <returns>A new headbar element.</returns>
        public static Headbar Generate
        (
            LanguageHandler languageHandler,
            DialogueSystemWindowAsset dialogueSystemWindowAsset,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            var headbar = HeadbarPresenter.CreateElement(languageHandler, dialogueSystemWindowAsset);

            new HeadbarObserver(headbar, dialogueSystemWindow).RegisterEvents();

            return headbar;
        }
    }
}