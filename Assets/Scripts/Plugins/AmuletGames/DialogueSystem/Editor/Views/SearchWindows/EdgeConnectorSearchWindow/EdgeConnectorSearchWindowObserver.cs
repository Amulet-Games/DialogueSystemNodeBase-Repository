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
        EdgeConnectorSearchWindowView view;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        LanguageHandler languageHandler;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        DialogueSystemWindow dialogueSystemWindow;


        /// <summary>
        /// Reference of the new created node from the SearchWindowEntrySelectedEvent.
        /// </summary>
        NodeBase node;


        /// <summary>
        /// The search window context's screen mouse position.
        /// </summary>
        Vector2 SearchWindowContextScreenMousePosition;


        /// <summary>
        /// Constructor of the edge connector search window observer class.
        /// </summary>
        /// <param name="view">The edge connector search window view to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        public EdgeConnectorSearchWindowObserver
        (
            EdgeConnectorSearchWindowView view,
            GraphViewer graphViewer,
            LanguageHandler languageHandler,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            this.view = view;
            this.graphViewer = graphViewer;
            this.languageHandler = languageHandler;
            this.dialogueSystemWindow = dialogueSystemWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge connector search window view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterSearchWindowEvents();
        }


        /// <summary>
        /// Register events to the search window component.
        /// </summary>
        void RegisterSearchWindowEvents()
            => new SearchWindowObserver(view.SearchWindow, SearchWindowEntrySelectedEvent).RegisterEvents();


        /// <summary>
        /// Register NodeCreatedEvent to the newly created node.
        /// </summary>
        void RegisterNodeCreatedEvents() => node.Callback.NodeCreatedEvent += NodeCreatedEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when an entry in the edge connector search window is selected.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        bool SearchWindowEntrySelectedEvent(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            SearchWindowContextScreenMousePosition = context.screenMousePosition;

            node = NodeManager.Instance.Spawn
            (
                graphViewer,
                nodeType: ((NodeTypeSearchTreeEntryUserData)searchTreeEntry.userData).NodeType,
                languageHandler
            );

            RegisterNodeCreatedEvents();

            graphViewer.Add(node);

            WindowChangedEvent.Invoke();

            return true;
        }


        /// <summary>
        /// The event to invoke when the a node has been created on the graph.
        /// </summary>
        void NodeCreatedEvent()
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

                connectToPort = node switch
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

                spawnPosition.y -= (node.topContainer.worldBound.height
                                  + connectToPort.localBound.position.y
                                  + NumberConfig.MANUAL_CREATE_Y_OFFSET)
                                  / graphViewer.scale;

                spawnPosition.x -= isInputConnector
                    ? node.localBound.width
                    : 0;

                node.SetPosition(newPos: new Rect(position: spawnPosition, size: Vector2Utility.Zero));
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
        }
    }
}