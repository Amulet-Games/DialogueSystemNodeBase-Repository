using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateRequestCallback : NodeCreateCallbackFrameBase
    <
        NodeCreateRequestCallback,
        NodeCreateRequestDetail,
        NodeCreateRequestObserver
    >
    {
        /// <summary>
        /// The approximate position of where the node will be created on the graph.
        /// </summary>
        Vector2 approxCreatePosition;


        /// <summary>
        /// The new created node.
        /// </summary>
        NodeBase node;


        /// <inheritdoc />
        public override NodeCreateRequestCallback Setup
        (
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow,
            NodeCreateRequestObserver observer
        )
        {
            base.Setup(graphViewer, languageHandler, dialogueSystemWindow, observer);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            CalculateApproxCreatePosition();

            CreateNode(searchTreeEntry);

            Observer.RegisterEvents(node, approxCreatePosition);

            GraphViewer.Add(node);

            WindowChangedEvent.Invoke();

            return true;
        }


        /// <summary>
        /// Calculate the approximate position of where to create a node element.
        /// </summary>
        void CalculateApproxCreatePosition()
        {
            // Calculate the direction vector from mouse screen position to window center position.
            Vector2 mouseToWindowCenterVector = DialogueSystemWindow.rootVisualElement.ChangeCoordinatesTo
            (
                dest: DialogueSystemWindow.rootVisualElement.parent,
                point: GraphViewer.ScreenMousePosition - DialogueSystemWindow.position.position
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