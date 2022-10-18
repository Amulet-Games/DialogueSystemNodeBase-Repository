using System.Collections.Generic;
using System.Linq;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSGraphView : GraphView
    {
        /// <summary>
        /// Reference of the dialogue system's serialize handler module.
        /// </summary>
        public DSSerializeHandler SerializeHandler;


        /// <summary>
        /// Reference of the dialogue system's node creation connector window module.
        /// </summary>
        public DSNodeCreationConnectorWindow NodeCreationConnectorWindow;

        /// <summary>
        /// Reference of the dialogue system's node creation request window module.
        /// </summary>
        DSNodeCreationRequestWindow nodeCreationRequestWindow;


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
            nodeCreationRequestWindow = DSNodeCreationRequestWindow.CreateInstance(this, dsWindow);
            NodeCreationConnectorWindow = DSNodeCreationConnectorWindow.CreateInstance(this, dsWindow);
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
            SetupGridBackground();

            SetupGraphSize();

            SetupGraphManipulator();

            SetupGraphZoom();

            SetupGraphViewChangedDelegate();

            SetupNodeCreationRequestAction();

            SetupDeleteSelectionDelegate();

            SetupFocusBlurEvent();

            AddStyleSheet();

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

            void SetupFocusBlurEvent()
            {
                RegisterCallback<FocusEvent>(GraphFocusAction);
                RegisterCallback<BlurEvent>(GraphBlurAction);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.DSGraphViewStyle);
            }

            void AddGraphToWindowRoot()
            {
                dsWindow.rootVisualElement.Add(this);
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

            InvokeDSWindowChangedEvent();

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
                    edgesToDelete[i].PreManualRemovedAction();
                    DisconnectPort(edgesToDelete[i]);
                }
            }

            void DeleteNodesFromList()
            {
                for (int i = 0; i < nodesToDeleteCount; i++)
                {
                    nodesToDelete[i].PreManualRemovedAction();
                    RemoveElement(nodesToDelete[i]);
                    nodesToDelete[i].PostManualRemovedAction();
                }
            }

            void InvokeDSWindowChangedEvent()
            {
                DSWindowChangedEvent.Invoke();
            }
        }


        /// <summary>
        /// Action that called when user requests to display the node creation window.
        /// </summary>
        /// <param name="context">A struct that represents the context when the user initiates creating a graph node.</param>
        void NodeCreationRequestAction(NodeCreationContext context)
        {
            if (Event.current != null)
            {
                // If user opened up the node creation request window by pressing space bar.
                nodeCreationRequestWindow.Open(GetCurrentEventMousePosition());
            }
            else
            {
                // If the user opened up the node creation request window through contextual menu.
                nodeCreationRequestWindow.Open(context.screenMousePosition);
            }
        }


        /// <summary>
        /// Action that called when the graph view module has gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void GraphFocusAction(FocusEvent evt) => dsWindow.IsGraphViewFocus = true;


        /// <summary>
        /// Action that called when the graph view module has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void GraphBlurAction(BlurEvent evt) => dsWindow.IsGraphViewFocus = false;


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


        // ----------------------------- Retrieve Current Event Mouse Position Services -----------------------------
        /// <summary>
        /// Returns the vector2 value of the current mouse position on screen whenver an unity's event is invoked.
        /// <para>Note that if there's no event getting invoked currently, this method may give you an null reference exception.</para>
        /// </summary>
        public static Vector2 GetCurrentEventMousePosition() 
            =>
            GUIUtility.GUIToScreenPoint(Event.current.mousePosition);


        // ----------------------------- Manipulate Port Connection Services -----------------------------
        /// <summary>
        /// Disconnects the specified single port from its connecting opponent port.
        /// </summary>
        /// <param name="port">The target port to start the disconnection from.</param>
        public void DisconnectPort(Port port)
        { 
            Edge edge = port.connections.First();

            port.Disconnect(edge);

            if (port.IsInput())
            {
                edge.output.Disconnect(edge);
            }
            else
            {
                edge.input.Disconnect(edge);
            }

            RemoveElement(edge);
        }


        /// <summary>
        /// Disconnects any single port that are connecting through the specified edge.
        /// </summary>
        /// <param name="edge">The edge of the two ports that are disconnecting.</param>
        public void DisconnectPort(Edge edge)
        {
            edge.input.Disconnect(edge);
            edge.output.Disconnect(edge);
            RemoveElement(edge);
        }


        /// <summary>
        /// Disconnects multi edge port from each of its connecting opponent port.
        /// </summary>
        /// <param name="port">The target port to start the disconnection from.</param>
        public void DisconnectPortMulti(Port port)
        {
            Edge[] connections = port.connections.ToArray();
            Edge edge;

            for (int i = 0; i < connections.Length; i++)
            {
                edge = connections[i];

                port.Disconnect(edge);

                if (port.IsInput())
                {
                    edge.output.Disconnect(edge);
                }
                else
                {
                    edge.input.Disconnect(edge);
                }

                RemoveElement(edge);
            }
        }


        /// <summary>
        /// Creates an new edge and connects the two specified ports with it.
        /// </summary>
        /// <param name="outputPort"></param>
        /// <param name="inputPort"></param>
        public Edge ConnectPorts(Port outputPort, Port inputPort)
        {
            // Create an new edge.
            Edge edge = new Edge()
            {
                output = outputPort,
                input = inputPort
            };

            // Connect to the edge.
            edge.output.Connect(edge);
            edge.input.Connect(edge);

            // Add the edge to the graph.
            Add(edge);

            // Return edge
            return edge;
        }
    }
}