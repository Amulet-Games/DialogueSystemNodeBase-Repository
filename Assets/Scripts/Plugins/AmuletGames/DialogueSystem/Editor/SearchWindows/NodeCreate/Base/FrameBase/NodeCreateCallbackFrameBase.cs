namespace AG.DS
{
    public abstract class NodeCreateCallbackFrameBase<TNodeCreateCallback>
        : NodeCreateCallbackBase
        where TNodeCreateCallback : NodeCreateCallbackBase
    {
        /// <summary>
        /// Setup for the node create callback frame base class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        /// <param name="observer">The node create observer to set for.</param>
        /// <returns>The after setup node create callback class.</returns>
        public virtual TNodeCreateCallback Setup
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dsWindow,
            NodeCreateObserver observer
        )
        {
            GraphViewer = graphViewer;
            LanguageHandler = languageHandler;
            DsWindow = dsWindow;
            Observer = observer;

            return null;
        }
    }
}