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
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create request window.</returns>
        public NodeCreateRequestWindow CreateRequest
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dsWindow
        )
        {
            return Create<NodeCreateRequestWindow, NodeCreateRequestCallback,
                    NodeCreateRequestDetail, NodeCreateObserver>(graphViewer, languageHandler, dsWindow);
        }


        /// <summary>
        /// Method for creating a new node create connector window.
        /// </summary>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create connector window.</returns>
        public NodeCreateConnectorWindow CreateConnector
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dsWindow
        )
        {
            return Create<NodeCreateConnectorWindow, NodeCreateConnectorCallback,
                    NodeCreateConnectorDetail, NodeCreateObserver>(graphViewer, languageHandler, dsWindow);
        }


        /// <summary>
        /// Method for creating a new node create window.
        /// </summary>
        /// 
        /// <typeparam name="TNodeCreateWindow">Type node create window.</typeparam>
        /// <typeparam name="TNodeCreateCallback">Type node create callback.</typeparam>
        /// <typeparam name="TNodeCreateDetail">Type node create detail.</typeparam>
        /// <typeparam name="TNodeCreateObserver">Type node create observer.</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create window.</returns>
        TNodeCreateWindow Create<TNodeCreateWindow, TNodeCreateCallback, TNodeCreateDetail, TNodeCreateObserver>
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dsWindow
        )
            where TNodeCreateWindow : NodeCreateWindowFrameBase<TNodeCreateWindow, TNodeCreateCallback, TNodeCreateDetail>, new()
            where TNodeCreateCallback : NodeCreateCallbackFrameBase<TNodeCreateCallback>, new()
            where TNodeCreateDetail : NodeCreateDetailBase, new()
            where TNodeCreateObserver : NodeCreateObserver, new()
        {
            var detail = new TNodeCreateDetail();
            var observer = new TNodeCreateObserver().Setup(detail, graphViewer);
            var callback = new TNodeCreateCallback().Setup(graphViewer, languageHandler, dsWindow, observer);
            var window = ScriptableObject.CreateInstance<TNodeCreateWindow>().Setup(callback, detail, graphViewer);

            return window;
        }
    }
}