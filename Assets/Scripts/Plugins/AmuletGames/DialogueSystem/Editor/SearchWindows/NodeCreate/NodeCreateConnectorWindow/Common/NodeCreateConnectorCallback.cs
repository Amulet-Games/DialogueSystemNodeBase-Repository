using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorCallback
    <
        TPort,
        TPortCreateDetail,
        TEdgeView
    >
        : NodeCreateCallbackFrameBase
    <
        NodeCreateConnectorCallback<TPort, TPortCreateDetail, TEdgeView>,
        NodeCreateConnectorDetail<TPort, TPortCreateDetail, TEdgeView>,
        NodeCreateConnectorObserver<TPort, TPortCreateDetail, TEdgeView>
    >
        where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdgeView>
        where TPortCreateDetail : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdgeView>
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
        public override NodeCreateConnectorCallback<TPort, TPortCreateDetail, TEdgeView> Setup
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow,
            NodeCreateConnectorObserver<TPort, TPortCreateDetail, TEdgeView> observer
        )
        {
            base.Setup(graphViewer, languageHandler, dialogueSystemWindow, observer);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            CalculateApproxCreatePosition(context);

            node = CreateNode(searchTreeEntry);

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
            mouseToWindowCenterVector = DialogueSystemWindow.rootVisualElement.ChangeCoordinatesTo
            (
                dest: DialogueSystemWindow.rootVisualElement.parent,
                point: context.screenMousePosition - DialogueSystemWindow.position.position
            );

            // And calculate its position in the graph viewer.
            approxCreatePosition = GraphViewer.contentViewContainer.WorldToLocal(p: mouseToWindowCenterVector);
        }


        /// <summary>
        /// Create a new node element.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        NodeBase CreateNode(SearchTreeEntry searchTreeEntry)
            => NodeManager.Instance.Spawn
            (
                GraphViewer,
                nodeType: ((NodeCreateEntry)searchTreeEntry).NodeType,
                LanguageHandler
            );
    }
}
