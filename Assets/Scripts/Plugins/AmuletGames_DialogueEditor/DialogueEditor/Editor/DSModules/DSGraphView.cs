using System.Collections.Generic;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSGraphView : GraphView
    {
        /// <summary>
        /// Is reframe the graph view after loaded the custom graph editor?
        /// </summary>
        public bool IsReframeGraphAfterWindowLoaded;

        /// <summary>
        /// Reference of the dialogue system's serialize handler module.
        /// </summary>
        public DSSerializeHandler SerializeHandler;


        /// <summary>
        /// Reference of the dialogue system's serach tree window.
        /// </summary>
        public DSSearchWindow SearchWindow;


        /// <summary>
        /// Reference of the dialogue system editor window module.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's graph module.
        /// </summary>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        public DSGraphView(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;

            SerializeHandler = new DSSerializeHandler(this);
            SearchWindow = ScriptableObject.CreateInstance<DSSearchWindow>();
        }


        // ----------------------------- Pre Setup -----------------------------
        /// <summary>
        /// Clear all the actions that have been registered to GraphViewChangedEvent
        /// </summary>
        public void ClearEvents()
        {
            graphViewChanged = null;
        }


        /// <summary>
        /// Register internal action to GraphViewChangedEvent
        /// </summary>
        public void RegisterEvents()
        {
            graphViewChanged += GraphViewChangedAction;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to initialize internal fields, create a new graph view element
        /// <br>and setups it's initial properties.</br>
        /// <para></para>
        /// <br>It's called by dialogue editor window, and executed after the creation of other module classes.</br>
        /// <br>But also before the containerSO started loading the previous saved elements.</br>
        /// </summary>
        public void PostSetup()
        {
            SetupGraphView();

            SetupSearchWindow();

            void SetupGraphView()
            {
                SetupGridBackground();

                SetupGraphSize();

                SetupGraphManipulator();

                SetupGraphZoom();

                SetupNodeCreationRequest();

                SetupGraphDeleteSelection();

                AddStyleSheets();

                AddGraphToWindowRoot();

                void SetupGridBackground()
                {
                    // GOAL: Add a visible grid to the background.

                    GridBackground grid = new GridBackground();
                    Insert(0, grid);
                    grid.StretchToParentSize();
                }

                void SetupGraphSize()
                {
                    this.StretchToParentSize();
                }

                void SetupGraphManipulator()
                {
                    this.AddManipulator(new ContentDragger());          // The ability to drag nodes around.
                    this.AddManipulator(new SelectionDragger());        // The ability to drag all selected nodes around.
                    this.AddManipulator(new RectangleSelector());       // The ability to drag select a rectangle area.
                    this.AddManipulator(new FreehandSelector());        // The ability to select a single node.
                }

                void SetupGraphZoom()
                {
                    // Default Min Scale = 0.25f;
                    // Default Max Scale = 1f;
                    SetupZoom(ContentZoomer.DefaultMinScale, 1.15f);
                }

                void SetupNodeCreationRequest()
                {
                    nodeCreationRequest = context => UnityEditor.Experimental.GraphView.SearchWindow.Open
                    (
                        new SearchWindowContext(context.screenMousePosition), SearchWindow
                    );
                }

                void SetupGraphDeleteSelection()
                {
                    deleteSelection = GraphDeleteSelectionAction;
                }

                void AddStyleSheets()
                {
                    styleSheets.Add(DSStylesConfig.DSGraphViewStyle);
                }

                void AddGraphToWindowRoot()
                {
                    dsWindow.rootVisualElement.Add(this);
                }
            }

            void SetupSearchWindow()
            {
                SearchWindow.PostSetup(this, dsWindow);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action to detect if user has changed anything on the graph and if so,
        /// <br>invoke the DSGraphViewChangedEvent.</br>
        /// </summary>
        /// <param name="change">Set of changes in the graph that can be intercepted.</param>
        /// <returns>Return values can be ignored.</returns>
        GraphViewChange GraphViewChangedAction(GraphViewChange change)
        {
            if (!dsWindow.hasUnsavedChanges)
            {
                // If users created new edges, removed any visual elements or moved any visual elements,
                if (change.edgesToCreate != null || change.elementsToRemove != null || change.movedElements != null)
                {
                    // invoke DSGraphViewChangedEvent.
                    DSGraphViewChangedEvent.Invoke();
                }
            }

            return change;
        }


        /// <summary>
        /// Action that called each time when graph elements are selected and deleted, and override the
        /// <br>base graph view behaviour on how to react if different types of elements are deleted.</br>
        /// </summary>
        /// <param name="operationName">Name of operation for undo/redo labels.</param>
        /// <param name="askUser">Whether or not to ask the user.</param>
        void GraphDeleteSelectionAction(string operationName, AskUser askUser)
        {
            Type edgeType;

            List<DSNodeBase> nodesToDelete;
            List<Edge> edgesToDelete;

            int selectionCount;
            int nodesToDeleteCount;

            SetupDeletingList();

            RearrangeDeletingList();

            DeleteEdgesFromList();

            DeleteNodesFromList();

            void SetupDeletingList()
            {
                edgeType = typeof(Edge);

                nodesToDelete = new List<DSNodeBase>();
                edgesToDelete = new List<Edge>();

                selectionCount = selection.Count;
                nodesToDeleteCount = 0;
            }

            void RearrangeDeletingList()
            {
                for (int i = 0; i < selectionCount; i++)
                {
                    // If the selected graph element is a node.
                    if (selection[i] is DSNodeBase node)
                    {
                        nodesToDelete.Add(node);
                        nodesToDeleteCount++;
                        continue;
                    }

                    // If the selected graph element is an edge.
                    if (selection[i].GetType() == edgeType)
                    {
                        edgesToDelete.Add((Edge)selection[i]);
                        continue;
                    }
                }
            }
        
            void DeleteEdgesFromList()
            {
                for (int i = 0; i < edgesToDelete.Count; i++)
                {
                    edgesToDelete[i].EdgeRemovedByManualAction();
                    RemoveElement(edgesToDelete[i]);
                }
            }

            void DeleteNodesFromList()
            {
                for (int i = 0; i < nodesToDeleteCount; i++)
                {
                    nodesToDelete[i].NodeRemovedByManualAction();
                    RemoveElement(nodesToDelete[i]);
                }
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Get all ports compatible with given port under certain conditions, 
        /// <br>to limit which nodes can connect to each other.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.GraphView.GetCompatiblePorts.html</para>
        /// </summary>
        /// <param name="connectFromPort">The starting port to validate against.</param>
        /// <param name="nodeAdapter">Parameter can be ignored.</param>
        /// <returns>List of compatible ports.</returns>
        public override List<Port> GetCompatiblePorts(Port connectFromPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new List<Port>();

            ports.ForEach((connectToPort) =>
            {
                // Same port cannot connect to itself.
                if (connectFromPort != connectToPort)
                {
                    // Start node cannot connect to start node
                    if (connectFromPort.node != connectToPort.node)
                    {
                        // Port cannot connect to the another port that has the same direction.
                        // *Input Port(A) -> Input Port(B) / Output Port(A) -> Output Port(B)
                        if (connectFromPort.direction != connectToPort.direction)
                        {
                            // Ports that aren't in the same port colors cannot connect.
                            if (connectFromPort.portColor == connectToPort.portColor)
                            {
                                compatiblePorts.Add(connectToPort);
                            }
                        }
                    }
                }
            });

            // return all the acceptable ports.
            return compatiblePorts;
        }


        // ----------------------------- Reframe Graph Services -----------------------------
        /// <summary>
        /// Focus view all elements in the graph.
        /// </summary>
        public void ReframeGraphAll() => FrameAll();
    }
}