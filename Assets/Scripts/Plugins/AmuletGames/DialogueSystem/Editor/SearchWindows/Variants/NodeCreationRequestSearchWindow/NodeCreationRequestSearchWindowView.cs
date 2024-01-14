namespace AG.DS
{
    public class NodeCreationRequestSearchWindowView
    {
        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SearchWindowBase SearchWindow;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        public LanguageHandler LanguageHandler;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        public DialogueSystemWindow DialogueSystemWindow;


        /// <summary>
        /// Constructor of the node creation request search window view class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        public NodeCreationRequestSearchWindowView
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            GraphViewer = graphViewer;
            LanguageHandler = languageHandler;
            DialogueSystemWindow = dialogueSystemWindow;
        }
    }
}