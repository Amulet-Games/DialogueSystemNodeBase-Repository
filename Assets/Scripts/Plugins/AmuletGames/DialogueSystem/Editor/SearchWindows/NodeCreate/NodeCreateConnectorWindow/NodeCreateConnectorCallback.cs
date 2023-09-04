using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorCallback
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : NodeCreateCallbackFrameBase
    <
        NodeCreateConnectorCallback<TPort, TEdge, TEdgeView>,
        NodeCreateConnectorDetail<TPort, TEdge, TEdgeView>,
        NodeCreateConnectorObserver<TPort, TEdge, TEdgeView>
    >
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
    {
        /// <summary>
        /// The direction vector from mouse screen position to window center position.
        /// </summary>
        Vector2 mouseToWindowCenterVector;


        /// <summary>
        /// The approximate position of where the node will be created on the graph.
        /// </summary>
        Vector2 approxCreatePosition;


        /// <summary>
        /// The new created node.
        /// </summary>
        NodeBase node;


        /// <inheritdoc />
        public override NodeCreateConnectorCallback<TPort, TEdge, TEdgeView> Setup
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dsWindow,
            NodeCreateConnectorObserver<TPort, TEdge, TEdgeView> observer
        )
        {
            base.Setup(graphViewer, languageHandler, dsWindow, observer);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            CalculateApproxCreatePosition(context);

            CreateNode(searchTreeEntry);

            Observer.RegisterEvents(node, approxCreatePosition);

            GraphViewer.Add(node);

            WindowChangedEvent.Invoke();

            return true;
        }


        /// <summary>
        /// Calculate the approximate position of where to create a node element.
        /// </summary>
        /// <param name="context">THe search window context to set for.</param>
        void CalculateApproxCreatePosition(SearchWindowContext context)
        {
            // Convert the direction from screen space to window space(?)
            mouseToWindowCenterVector = DsWindow.rootVisualElement.ChangeCoordinatesTo
            (
                dest: DsWindow.rootVisualElement.parent,
                point: context.screenMousePosition - DsWindow.position.position
            );

            // And calculate its position in the graph viewer.
            approxCreatePosition = GraphViewer.contentViewContainer.WorldToLocal(p: mouseToWindowCenterVector);
        }


        /// <summary>
        /// Create a new node element.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        void CreateNode(SearchTreeEntry searchTreeEntry)
        {
            node = NodeManager.Instance.Spawn(
                GraphViewer,
                nodeType: ((NodeCreateEntry)searchTreeEntry).NodeType,
                LanguageHandler
            );
        }
    }
}
