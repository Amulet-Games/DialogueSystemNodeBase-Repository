using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace AG.DS
{
    public class GraphViewerCallback
    {
        /// <summary>
        /// The targeting graph viewer element.
        /// </summary>
        public GraphViewer graphViewer;


        /// <summary>
        /// Reference of the dialogue editor window module.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph viewer callback class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window module to set for.</param>
        public GraphViewerCallback
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow
        )
        {
            this.graphViewer = graphViewer;
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Set Callback Delegates -----------------------------
        /// <summary>
        /// Set the graph viewer's callbacks. 
        /// </summary>
        public void SetCallbacks()
        {
            graphViewer.graphViewChanged = GraphViewChanged;
            graphViewer.nodeCreationRequest = NodeCreationRequest;
            graphViewer.deleteSelection = DeleteSelection;
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The action to invoke when certain changes have occurred in the graph.
        /// </summary>
        /// <param name="change">Set of changes in the graph that can be intercepted.</param>
        /// <returns>Set of changes in the graph that can be intercepted.</returns>
        GraphViewChange GraphViewChanged(GraphViewChange change)
        {
            if (!dsWindow.hasUnsavedChanges)
            {
                // If user created any new edges, removed any visual elements or moved any visual elements,
                if (change.edgesToCreate != null
                 || change.elementsToRemove != null
                 || change.movedElements != null
                )
                {
                    // invoke GraphViewChangedEvent.
                    GraphViewChangedEvent.Invoke();
                }
            }

            return change;
        }


        /// <summary>
        /// The action to invoke when the user requests to display the node creation window.
        /// </summary>
        /// <param name="context">A struct that represents the context when the user initiates creating a graph node.</param>
        void NodeCreationRequest(NodeCreationContext context)
        {
            if (Event.current != null)
            {
                // If the user opened up the node creation request window by pressing space bar.
                graphViewer.NodeCreationRequestWindow.Open(
                    screenPositionToShow: GraphViewer.GetCurrentEventMousePosition()
                );
            }
            else
            {
                // If the user opened up the node creation request window through contextual menu.
                graphViewer.NodeCreationRequestWindow.Open(
                    screenPositionToShow: context.screenMousePosition
                );
            }
        }


        /// <summary>
        /// The action to invoke when deleting any selected graph elements. 
        /// </summary>
        /// <param name="operationName">Name of operation for undo/redo labels.</param>
        /// <param name="askUser">Whether or not to ask the user.</param>
        void DeleteSelection(string operationName, AskUser askUser)
        {
            DeleteSelectedElements();

            InvokeDSWindowChangedEvent();

            void DeleteSelectedElements()
            {
                var selectionCount = graphViewer.selection.Count;
                for (int i = 0; i < selectionCount; i++)
                {
                    var selection = graphViewer.selection[i];

                    if (selection is NodeBase node)
                    {
                        node.PreManualRemoveAction();

                        graphViewer.Remove(node);

                        node.PostManualRemoveAction();
                    }
                    else if (selection != null && selection is EdgeBase edge)
                    {
                        edge.PreManualRemoveAction();

                        graphViewer.Remove(edge);

                        edge.PostManualRemoveAction();
                    }
                }
            }

            void InvokeDSWindowChangedEvent()
            {
                WindowChangedEvent.Invoke();
            }
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the graph viewer.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusEvent();

            RegisterBlurEvent();
        }


        /// <summary>
        /// Register FocusEvent to the graph viewer.
        /// </summary>
        void RegisterFocusEvent() =>
            graphViewer.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the graph viewer.
        /// </summary>
        void RegisterBlurEvent() =>
            graphViewer.RegisterCallback<BlurEvent>(BlurEvent);


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
    }
}