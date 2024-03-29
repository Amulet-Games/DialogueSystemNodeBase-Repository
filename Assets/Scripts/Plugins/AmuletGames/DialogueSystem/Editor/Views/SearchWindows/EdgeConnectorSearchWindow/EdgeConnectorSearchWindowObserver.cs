using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EdgeConnectorSearchWindowObserver
    {
        /// <summary>
        /// The targeting edge connector search window.
        /// </summary>
        public EdgeConnectorSearchWindowView view;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        DialogueSystemWindow dialogueSystemWindow;


        /// <summary>
        /// Reference of the new created node from the SearchWindowEntrySelectedEvent.
        /// </summary>
        NodeBase nodeProduct;


        /// <summary>
        /// The search window context's screen mouse position.
        /// </summary>
        Vector2 SearchWindowContextScreenMousePosition;


        /// <summary>
        /// Constructor of the edge connector search window observer class.
        /// </summary>
        /// <param name="view">The edge connector search window view to set for.</param>
        public EdgeConnectorSearchWindowObserver(EdgeConnectorSearchWindowView view)
        {
            this.view = view;
            graphViewer = view.GraphViewer;
            dialogueSystemWindow = view.DialogueSystemWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge connector search window.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterSearchWindowEvents();
        }


        /// <summary>
        /// Register events to the search window component.
        /// </summary>
        public void RegisterSearchWindowEvents()
            => new SearchWindowObserver(view.SearchWindow, SearchWindowEntrySelectedEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when an entry in the edge connector search window is selected.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        bool SearchWindowEntrySelectedEvent(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            SearchWindowContextScreenMousePosition = context.screenMousePosition;

            nodeProduct = NodeManager.Instance.Spawn
            (
                graphViewer,
                nodeType: ((NodeTypeSearchTreeEntryUserData)searchTreeEntry.userData).NodeType,
                view.LanguageHandler
            );

            nodeProduct.ExecuteOnceOnGeometryChanged(NodeProductCreatedEvent);

            graphViewer.Add(nodeProduct);

            WindowChangedEvent.Invoke();

            return true;
        }


        /// <summary>
        /// The event to invoke when the new node has been created on the graph.
        /// </summary>
        /// <param name="evt">The registering event</param>
        void NodeProductCreatedEvent(GeometryChangedEvent evt)
        {
            Port connectToPort;
            bool isInputConnector = view.ConnectorPort.IsInput();

            // Initialize the node product position
            {
                // Convert the direction from screen space to window space(?)
                var mouseToWindowCenterVector = dialogueSystemWindow.rootVisualElement.ChangeCoordinatesTo
                (
                    dest: dialogueSystemWindow.rootVisualElement.parent,
                    point: SearchWindowContextScreenMousePosition - dialogueSystemWindow.position.position
                );

                // And calculate its position in the graph viewer.
                var spawnPosition = graphViewer.contentViewContainer.WorldToLocal(p: mouseToWindowCenterVector);

                connectToPort = nodeProduct switch
                {
                    BooleanNode node => isInputConnector
                        ? node.View.TrueOutputPort
                        : node.View.InputPort,

                    DialogueNode node => isInputConnector
                        ? node.View.OutputPort
                        : node.View.InputPort,
                        
                    EndNode node => isInputConnector
                        ? null
                        : node.View.InputPort,

                    EventNode node => isInputConnector
                        ? node.View.OutputPort
                        : node.View.InputPort,

                    OptionBranchNode node => isInputConnector
                        ? node.View.OutputPort
                        : node.View.InputOptionPortCell.Port,

                    OptionRootNode node => isInputConnector
                        ? node.View.OutputOptionPortGroup.BaseOptionPortCell.Port
                        : node.View.InputPort,

                    PreviewNode node => isInputConnector
                        ? node.View.OutputPort
                        : node.View.InputPort,

                    StartNode node => isInputConnector
                        ? node.View.OutputPort
                        : null,

                    _ => throw new ArgumentException("Node creation failed: cannot retrieve 'connectToPort' from invalid node type.")
                };

                spawnPosition.y -= (nodeProduct.topContainer.worldBound.height
                                  + connectToPort.localBound.position.y
                                  + NumberConfig.MANUAL_CREATE_Y_OFFSET)
                                  / graphViewer.scale;

                spawnPosition.x -= isInputConnector
                    ? nodeProduct.localBound.width
                    : 0;

                nodeProduct.SetPosition(newPos: new Rect(position: spawnPosition, size: Vector2Utility.Zero));
            }

            // Connect the connector port to the node product
            {
                var port = view.ConnectorPort;

                if (port.IsSingle() && port.connected)
                {
                    port.Disconnect(graphViewer);
                }

                var edge = EdgeFactory.Generate
                (
                    model: view.EdgeModel,
                    input: isInputConnector ? port : connectToPort,
                    output: !isInputConnector ? port : connectToPort
                );

                graphViewer.Add(edge);
            }

            nodeProduct.Callback.OnCreate();
        }
    }
}