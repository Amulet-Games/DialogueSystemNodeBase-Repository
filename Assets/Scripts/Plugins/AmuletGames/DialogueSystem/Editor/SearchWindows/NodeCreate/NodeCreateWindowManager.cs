using UnityEngine;

namespace AG.DS
{
    public class NodeCreateWindowManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static NodeCreateWindowManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the node create window manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Create -----------------------------
        /// <summary>
        /// Method for creating a new node create request window.
        /// </summary>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create request window.</returns>
        public NodeCreateRequestWindow CreateRequestWindow
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        => Create<NodeCreateRequestCallback, NodeCreateRequestDetail,
            NodeCreateRequestObserver, NodeCreateRequestWindow>(graphViewer, languageHandler, dialogueSystemWindow);


        /// <summary>
        /// Method for creating a new node create default connector window.
        /// </summary>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create default connector window.</returns>
        public NodeCreateDefaultConnectorWindow CreateDefaultConnectorWindow
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        => CreateConnector
            <NodeCreateConnectorCallback,
             NodeCreateConnectorDetail,
             NodeCreateConnectorObserver,
             NodeCreateDefaultConnectorWindow>
            (graphViewer, languageHandler, dialogueSystemWindow);


        /// <summary>
        /// Method for creating a new node create option connector window.
        /// </summary>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create option connector window.</returns>
        public NodeCreateOptionConnectorWindow CreateOptionConnectorWindow
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        => CreateConnector
            <NodeCreateConnectorCallback,
             NodeCreateConnectorDetail,
             NodeCreateConnectorObserver,
             NodeCreateOptionConnectorWindow>
            (graphViewer, languageHandler, dialogueSystemWindow);


        /// <summary>
        /// Method for creating a new node create request window.
        /// </summary>
        /// 
        /// <typeparam name="TNodeCreateCallback">Type node create callback</typeparam>
        /// <typeparam name="TNodeCreateDetail">Type node create detail</typeparam>
        /// <typeparam name="TNodeCreateObserver">Type node create observer</typeparam>
        /// <typeparam name="TNodeCreateWindow">Type node create window</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create request window.</returns>
        TNodeCreateWindow Create<TNodeCreateCallback, TNodeCreateDetail, TNodeCreateObserver, TNodeCreateWindow>
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
            where TNodeCreateCallback : NodeCreateCallbackFrameBase<TNodeCreateCallback, TNodeCreateDetail, TNodeCreateObserver>, new()
            where TNodeCreateDetail : NodeCreateDetailBase, new()
            where TNodeCreateObserver : NodeCreateObserverFrameBase<TNodeCreateDetail, TNodeCreateObserver>, new()
            where TNodeCreateWindow : NodeCreateWindowFrameBase<TNodeCreateCallback, TNodeCreateDetail, TNodeCreateWindow>, new()
        {
            var detail = new TNodeCreateDetail();
            var observer = new TNodeCreateObserver().Setup(detail, graphViewer);
            var callback = new TNodeCreateCallback().Setup(graphViewer, languageHandler, dialogueSystemWindow, observer);
            var window = ScriptableObject.CreateInstance<TNodeCreateWindow>().Setup(callback, detail, graphViewer);

            return window;
        }


        /// <summary>
        /// Method for creating a new node create connector window.
        /// </summary>
        /// 
        /// <typeparam name="TNodeCreateConnectorCallback">Type node create callback</typeparam>
        /// <typeparam name="TNodeCreateConnectorDetail">Type node create detail</typeparam>
        /// <typeparam name="TNodeCreateConnectorObserver">Type node create observer</typeparam>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create window</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create connector window.</returns>
        TNodeCreateConnectorWindow CreateConnector
        <
            TNodeCreateConnectorCallback,
            TNodeCreateConnectorDetail,
            TNodeCreateConnectorObserver,
            TNodeCreateConnectorWindow
        >
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
            where TNodeCreateConnectorCallback : NodeCreateConnectorCallback, new()
            where TNodeCreateConnectorDetail : NodeCreateConnectorDetail, new()
            where TNodeCreateConnectorObserver : NodeCreateConnectorObserver, new()
            where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>, new()
        {
            var detail = new TNodeCreateConnectorDetail();
            var observer = new TNodeCreateConnectorObserver().Setup(detail, graphViewer);
            var callback = new TNodeCreateConnectorCallback().Setup(graphViewer, languageHandler, dialogueSystemWindow, observer);
            var window = ScriptableObject.CreateInstance<TNodeCreateConnectorWindow>().Setup(callback, detail, graphViewer);

            return window;
        }
    }
}