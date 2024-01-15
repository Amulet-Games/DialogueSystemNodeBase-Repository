using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeCreationRequestSearchWindowObserver
    {
        /// <summary>
        /// The targeting node creation request search window.
        /// </summary>
        public NodeCreationRequestSearchWindowView view;


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
        /// Constructor of the node creation request search window observer class.
        /// </summary>
        /// <param name="view">The node creation request search window view to set for.</param>
        public NodeCreationRequestSearchWindowObserver(NodeCreationRequestSearchWindowView view)
        {
            this.view = view;
            graphViewer = view.GraphViewer;
            dialogueSystemWindow = view.DialogueSystemWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node creation request search window.
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
        /// The event to invoke when an entry in the node creation request search window is selected.
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        bool SearchWindowEntrySelectedEvent(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            nodeProduct = NodeManager.Instance.Spawn
            (
                graphViewer,
                nodeType: ((NodeCreateEntry)searchTreeEntry).NodeType,
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
            // Initialize the node product position
            {
                // Convert the direction from screen space to window space(?)
                var mouseToWindowCenterVector = dialogueSystemWindow.rootVisualElement.ChangeCoordinatesTo
                (
                    dest: dialogueSystemWindow.rootVisualElement.parent,
                    point: GUIUtility.GUIToScreenPoint(Event.current.mousePosition) - dialogueSystemWindow.position.position
                );

                // And calculate its position in the graph viewer.
                var spawnPosition = graphViewer.contentViewContainer.WorldToLocal(p: mouseToWindowCenterVector);

                var referenceYAxisPort = nodeProduct switch
                {
                    BooleanNode node => node.View.InputPort,
                    DialogueNode node => node.View.InputPort,
                    EndNode node => node.View.InputPort,
                    EventNode node => node.View.InputPort,
                    OptionBranchNode node => node.View.InputOptionPortCell.Port,
                    OptionRootNode node => node.View.InputPort,
                    PreviewNode node => node.View.InputPort,
                    StartNode node => node.View.OutputPort,
                    StoryNode node => node.View.InputPort,
                    _ => throw new ArgumentException("Node creation failed: cannot retrieve 'referenceYAxisPort' from invalid node type.")
                };

                spawnPosition.y -= (nodeProduct.topContainer.worldBound.height
                                  + referenceYAxisPort.localBound.position.y
                                  + NumberConfig.MANUAL_CREATE_Y_OFFSET)
                                  / graphViewer.scale;

                spawnPosition.x -= nodeProduct.localBound.width / 2;

                nodeProduct.SetPosition(newPos: new Rect(position: spawnPosition, size: Vector2Utility.Zero));
            }

            nodeProduct.Callback.OnCreate();
        }
    }
}