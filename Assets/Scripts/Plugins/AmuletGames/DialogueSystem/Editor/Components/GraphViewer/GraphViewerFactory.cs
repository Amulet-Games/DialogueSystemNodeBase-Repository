namespace AG.DS
{
    public class GraphViewerFactory
    {
        /// <summary>
        /// Generate a new graph viewer element.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// <returns>A new graph viewer element.</returns>
        public static GraphViewer Generate
        (
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            var graphViewer = GraphViewerPresenter.CreateElement();

            new GraphViewerObserver(graphViewer, languageHandler, dialogueSystemWindow).RegisterEvents();

            return graphViewer;
        }
    }
}