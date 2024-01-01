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
        => Create
            <DefaultPort, PortModel, DefaultEdge, DefaultEdgeView,
            NodeCreateConnectorCallback<DefaultPort, PortModel, DefaultEdge, DefaultEdgeView>,
            NodeCreateConnectorDetail<DefaultPort, PortModel, DefaultEdge, DefaultEdgeView>,
            NodeCreateConnectorObserver<DefaultPort, PortModel, DefaultEdge, DefaultEdgeView>,
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
        => Create
            <OptionPort, OptionPortModel, OptionEdge, OptionEdgeView,
            NodeCreateConnectorCallback<OptionPort, OptionPortModel, OptionEdge, OptionEdgeView>,
            NodeCreateConnectorDetail<OptionPort, OptionPortModel, OptionEdge, OptionEdgeView>,
            NodeCreateConnectorObserver<OptionPort, OptionPortModel, OptionEdge, OptionEdgeView>,
            NodeCreateOptionConnectorWindow>
            (graphViewer, languageHandler, dialogueSystemWindow);


        /// <summary>
        /// Method for creating a new node create window.
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
        /// <returns>A new node create window.</returns>
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
        /// Method for creating a new node create window.
        /// <br>ScriptableObject.CreateInstance doesn't except generic object, so the node create connector window needs to be a derived class.</br>
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortCreateDetail">Type port create detail</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TNodeCreateConnectorCallback">Type node create callback</typeparam>
        /// <typeparam name="TNodeCreateConnectorDetail">Type node create detail</typeparam>
        /// <typeparam name="TNodeCreateConnectorObserver">Type node create observer</typeparam>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create window</typeparam>
        /// 
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        /// 
        /// <returns>A new node create window.</returns>
        TNodeCreateConnectorWindow Create
        <
            TPort,
            TPortCreateDetail,
            TEdge,
            TEdgeView,
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
            where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TPortCreateDetail : PortModel
            where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TNodeCreateConnectorCallback : NodeCreateConnectorCallback<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TNodeCreateConnectorDetail : NodeCreateConnectorDetail<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TNodeCreateConnectorObserver : NodeCreateConnectorObserver<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView, TNodeCreateConnectorWindow>, new()
        {
            var detail = new TNodeCreateConnectorDetail();
            var observer = new TNodeCreateConnectorObserver().Setup(detail, graphViewer);
            var callback = new TNodeCreateConnectorCallback().Setup(graphViewer, languageHandler, dialogueSystemWindow, observer);
            var window = ScriptableObject.CreateInstance<TNodeCreateConnectorWindow>().Setup(callback, detail, graphViewer);

            return window;
        }
    }
}