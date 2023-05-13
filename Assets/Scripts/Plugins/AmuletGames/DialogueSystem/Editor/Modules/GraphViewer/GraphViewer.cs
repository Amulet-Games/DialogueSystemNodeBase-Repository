using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphViewer : GraphView
    {
        /// <summary>
        /// Reference of the serialize handler module.
        /// </summary>
        public SerializeHandler SerializeHandler;


        /// <summary>
        /// Reference of the node creation connector window module.
        /// </summary>
        public NodeCreationConnectorWindow NodeCreationConnectorWindow;


        /// <summary>
        /// Reference of the node creation request window module.
        /// </summary>
        public NodeCreationRequestWindow NodeCreationRequestWindow;


        /// <summary>
        /// Reference of the dialogue editor window module.
        /// </summary>
        public DialogueEditorWindow DsWindow;


        /// <summary>
        /// Is the graph viewer in focus at the moment?
        /// </summary>
        public bool IsFocus;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph viewer element class.
        /// </summary>
        /// <param name="dsWindow">The dialogue editor window module to set for.</param>
        public GraphViewer(DialogueEditorWindow dsWindow)
        {
            DsWindow = dsWindow;

            SerializeHandler = new(this);
            NodeCreationRequestWindow = NodeCreationRequestWindow.CreateInstance(this, dsWindow);
            NodeCreationConnectorWindow = NodeCreationConnectorWindow.CreateInstance(this, dsWindow);
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class.
        /// </summary>
        public void PostSetup()
        {
            SetupGridBackground();

            SetupGraphSize();

            SetupGraphManipulator();

            SetupGraphZoom();

            SetupGraphViewChangedDelegate();

            SetupNodeCreationRequestAction();

            SetupDeleteSelectionDelegate();

            SetupFocusBlurEvent();

            SetupInputHint();

            AddStyleSheet();

            AddGraphToWindowRoot();

            void SetupGridBackground()
            {
                // Add a visible grid to the background.
                GridBackground grid = new();
                Insert(index: 0, element: grid);
                grid.StretchToParentSize();
            }

            void SetupGraphSize()
            {
                this.StretchToParentSize();
            }

            void SetupGraphManipulator()
            {
                this.AddManipulator(manipulator: new ContentDragger());          // The ability to drag nodes around.
                this.AddManipulator(manipulator: new SelectionDragger());        // The ability to drag all selected nodes around.
                this.AddManipulator(manipulator: new RectangleSelector());       // The ability to drag select a rectangle area.
                this.AddManipulator(manipulator: new FreehandSelector());        // The ability to select a single node.
            }

            void SetupGraphZoom()
            {
                // Default Min Scale = 0.25f;
                // Default Max Scale = 1f;
                SetupZoom
                (
                    minScaleSetup: ContentZoomer.DefaultMinScale,
                    maxScaleSetup: 1.15f
                );
            }

            void SetupGraphViewChangedDelegate()
            {
                graphViewChanged = GraphViewChangedAction;
            }

            void SetupNodeCreationRequestAction()
            {
                nodeCreationRequest = NodeCreationRequestAction;
            }

            void SetupDeleteSelectionDelegate()
            {
                deleteSelection = GraphDeleteSelectionAction;
            }

            void SetupInputHint()
            {
                InputHint.Instance = InputHintPresenter.CreateElements(graphViewer: this);
                contentViewContainer.Add(InputHint.Instance);
            }

            void SetupFocusBlurEvent()
            {
                RegisterCallback<FocusEvent>(GraphFocusAction);
                RegisterCallback<BlurEvent>(GraphBlurAction);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSGraphViewerStyle);
            }

            void AddGraphToWindowRoot()
            {
                DsWindow.rootVisualElement.Add(this);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when new changes occurred to the graph.
        /// </summary>
        /// <param name="change">Set of changes in the graph that can be intercepted.</param>
        /// <returns>Return values can be ignored.</returns>
        GraphViewChange GraphViewChangedAction(GraphViewChange change)
        {
            if (!DsWindow.hasUnsavedChanges)
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
        /// The action to invoke when the user requested to display the node creation window.
        /// </summary>
        /// <param name="context">A struct that represents the context when the user initiates creating a graph node.</param>
        void NodeCreationRequestAction(NodeCreationContext context)
        {
            if (Event.current != null)
            {
                // If user opened up the node creation request window by pressing space bar.
                NodeCreationRequestWindow.Open(
                    screenPositionToShow: GetCurrentEventMousePosition()
                );
            }
            else
            {
                // If the user opened up the node creation request window through contextual menu.
                NodeCreationRequestWindow.Open(
                    screenPositionToShow: context.screenMousePosition
                );
            }
        }


        /// <summary>
        /// The action to invoke when deleting any selected graph elements. 
        /// </summary>
        /// <param name="operationName">Name of operation for undo/redo labels.</param>
        /// <param name="askUser">Whether or not to ask the user.</param>
        void GraphDeleteSelectionAction(string operationName, AskUser askUser)
        {
            DeleteSelectedElements();

            InvokeDSWindowChangedEvent();

            void DeleteSelectedElements()
            {
                var selectionCount = selection.Count;
                for (int i = 0; i < selectionCount; i++)
                {
                    if (selection[i] is NodeBase node)
                    {
                        node.PreManualRemoveAction();

                        Remove(node);

                        node.PostManualRemoveAction();
                    }
                    else if (selection[i] != null && selection[i] is EdgeBase edge)
                    {
                        edge.PreManualRemoveAction();

                        Remove(edge);

                        edge.PostManualRemoveAction();
                    }
                }
            }

            void InvokeDSWindowChangedEvent()
            {
                WindowChangedEvent.Invoke();
            }
        }


        /// <summary>
        /// The action to invoke when when the graph viewer element gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void GraphFocusAction(FocusEvent evt) => IsFocus = true;


        /// <summary>
        /// The action to invoke when when the graph viewer element lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void GraphBlurAction(BlurEvent evt) => IsFocus = false;


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
            List<Port> compatiblePorts = new();

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


        // ----------------------------- Reframe Graph -----------------------------
        /// <summary>
        /// Focus view all elements in the graph.
        /// </summary>
        public void ReframeGraphAll() => FrameAll();


        // ----------------------------- Retrieve Current Event Mouse Position -----------------------------
        /// <summary>
        /// Returns the vector2 value of the current mouse position on screen whenever an unity's event is invoked.
        /// <para>Note that if there's no event getting invoked currently, this method may give you an null reference exception.</para>
        /// </summary>
        public static Vector2 GetCurrentEventMousePosition() => GUIUtility.GUIToScreenPoint(Event.current.mousePosition);


        // ----------------------------- Remove -----------------------------
        /// <summary>
        /// Remove the given edge from the graph, and remove it from the serialize handler's cache.
        /// </summary>
        /// <param name="edge">The targeting edge.</param>
        public void Remove(EdgeBase edge)
        {
            RemoveElement(edge);
            SerializeHandler.RemoveCacheEdge(edge);
        }


        /// <summary>
        /// Remove the given node from the graph, and remove it from the serialize handler's cache.
        /// </summary>
        /// <param name="edge">The targeting edge.</param>
        public void Remove(NodeBase node)
        {
            RemoveElement(node);
            SerializeHandler.RemoveCacheNode(node);
        }


        // ----------------------------- Add -----------------------------
        /// <summary>
        /// Add the given edge to the graph, and add it to the serialize handler's cache.
        /// </summary>
        /// <param name="edge">The targeting edge.</param>
        public void Add(EdgeBase edge)
        {
            AddElement(edge);
            SerializeHandler.AddCacheEdge(edge);
        }


        /// <summary>
        /// Add the given node to the graph, and add it to the serialize handler's cache.
        /// </summary>
        /// <param name="node">The target node.</param>
        public void Add(NodeBase node)
        {
            AddElement(node);
            SerializeHandler.AddCacheNode(node);
        }
    }
}