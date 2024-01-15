using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace AG.DS
{
    public class GraphViewerObserver
    {
        /// <summary>
        /// The targeting graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        DialogueSystemWindow dialogueSystemWindow;


        /// <summary>
        /// Constructor of the graph viewer observer class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        public GraphViewerObserver
        (
            GraphViewer graphViewer,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            this.graphViewer = graphViewer;
            this.dialogueSystemWindow = dialogueSystemWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the graph viewer.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusEvent();

            RegisterBlurEvent();

            RegisterGraphViewChangedEvent();

            RegisterNodeCreationRequestEvent();

            RegisterDeleteSelectionEvent();

            RegisterNodeCreationRequestSearchWindowEvents();

            RegisterEdgeConnectorSearchWindowEvents();

            RegisterOptionEdgeConnectorSearchWindowEvents();
        }


        /// <summary>
        /// Register FocusEvent to the graph viewer.
        /// </summary>
        void RegisterFocusEvent() => graphViewer.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the graph viewer.
        /// </summary>
        void RegisterBlurEvent() => graphViewer.RegisterCallback<BlurEvent>(BlurEvent);


        /// <summary>
        /// Register GraphViewChangedEvent to the graph viewer.
        /// </summary>
        void RegisterGraphViewChangedEvent() => graphViewer.graphViewChanged = GraphViewChangedEvent;


        /// <summary>
        /// Register NodeCreationRequestEvent to the graph viewer.
        /// </summary>
        void RegisterNodeCreationRequestEvent() => graphViewer.nodeCreationRequest = NodeCreationRequestEvent;


        /// <summary>
        /// Register DeleteSelectionEvent to the graph viewer.
        /// </summary>
        void RegisterDeleteSelectionEvent() => graphViewer.deleteSelection = DeleteSelectionEvent;


        /// <summary>
        /// Register events to the node creation request search window.
        /// </summary>
        void RegisterNodeCreationRequestSearchWindowEvents()
            => new NodeCreationRequestSearchWindowObserver(graphViewer.NodeCreationRequestSearchWindowView).RegisterEvents();


        /// <summary>
        /// Register events to the edge connector search window.
        /// </summary>
        void RegisterEdgeConnectorSearchWindowEvents()
            => new EdgeConnectorSearchWindowObserver(graphViewer.EdgeConnectorSearchWindowView).RegisterEvents();


        /// <summary>
        /// Register events to the option edge connector search window.
        /// </summary>
        void RegisterOptionEdgeConnectorSearchWindowEvents()
            => new EdgeConnectorSearchWindowObserver(graphViewer.OptionEdgeConnectorSearchWindowView).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the graph viewer has given focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusEvent(FocusEvent evt)
        {
            graphViewer.IsFocus = true;
        }


        /// <summary>
        /// The event to invoke when the graph viewer has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void BlurEvent(BlurEvent evt)
        {
            graphViewer.IsFocus = false;
        }


        /// <summary>
        /// The action to invoke when certain changes have occurred in the graph.
        /// </summary>
        /// <param name="change">Set of changes in the graph that can be intercepted.</param>
        /// <returns>Set of changes in the graph that can be intercepted.</returns>
        GraphViewChange GraphViewChangedEvent(GraphViewChange change)
        {
            if (!dialogueSystemWindow.hasUnsavedChanges)
            {
                // If user created any new edges, removed any visual elements or moved any visual elements,
                if (change.edgesToCreate != null
                 || change.elementsToRemove != null
                 || change.movedElements != null
                )
                {
                    WindowChangedEvent.Invoke();
                }
            }

            return change;
        }


        /// <summary>
        /// The action to invoke when the user requests to display the node creation window.
        /// </summary>
        /// <param name="context">A struct that represents the context when the user initiates creating a graph node.</param>
        void NodeCreationRequestEvent(NodeCreationContext context)
        {
            graphViewer.NodeCreationRequestSearchWindowView.SearchWindow.OpenWindow(openScreenPosition: context.screenMousePosition);
        }


        /// <summary>
        /// The action to invoke when deleting any selected graph elements. 
        /// </summary>
        /// <param name="operationName">Name of operation for undo/redo labels.</param>
        /// <param name="askUser">Whether or not to ask the user.</param>
        void DeleteSelectionEvent(string operationName, AskUser askUser)
        {
            // Delete selected elements
            {
                List<NodeBase> nodesToDelete = new();
                List<EdgeBase> edgesToDelete = new();

                // Cache selected elements
                for (int i = 0; i < graphViewer.selection.Count; i++)
                {
                    if (graphViewer.selection[i] is NodeBase node)
                    {
                        nodesToDelete.Add(node);
                    }
                    else if (graphViewer.selection[i] is EdgeBase edge)
                    {
                        edgesToDelete.Add(edge);
                    }
                }

                // Delete nodes
                for (int i = 0; i < nodesToDelete.Count; i++)
                {
                    nodesToDelete[i].Callback.OnPreRemoveByUser(graphViewer);

                    graphViewer.Remove(nodesToDelete[i]);

                    nodesToDelete[i].Callback.OnPostRemoveByUser(graphViewer);
                }

                // Delete edges
                for (int i = 0; i < edgesToDelete.Count; i++)
                {
                    if (edgesToDelete[i] == null)
                        continue;

                    edgesToDelete[i].Callback.OnPreRemoveByUser(graphViewer);

                    graphViewer.Remove(edgesToDelete[i]);

                    edgesToDelete[i].Callback.OnPostRemoveByUser(graphViewer);
                }
            }

            WindowChangedEvent.Invoke();
        }
    }
}