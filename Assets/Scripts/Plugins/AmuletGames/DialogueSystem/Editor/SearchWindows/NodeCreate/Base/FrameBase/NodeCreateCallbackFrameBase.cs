namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCreateCallbackFrameBase
    <
        TNodeCreateCallback,
        TNodeCreateDetail,
        TNodeCreateObserver
    >
        : NodeCreateCallbackBase
        where TNodeCreateCallback : NodeCreateCallbackFrameBase<TNodeCreateCallback, TNodeCreateDetail, TNodeCreateObserver>
        where TNodeCreateDetail : NodeCreateDetailBase
        where TNodeCreateObserver : NodeCreateObserverFrameBase<TNodeCreateDetail, TNodeCreateObserver>
    {
        /// <summary>
        /// Reference of the node create observer.
        /// </summary>
        protected TNodeCreateObserver Observer;


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
            TNodeCreateObserver observer
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