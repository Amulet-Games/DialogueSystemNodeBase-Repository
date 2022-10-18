using System.Linq;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSDefaultPort : DSPortBase
    {
        /// <summary>
        /// Action for disconnecting the port from its current opponent port.
        /// </summary>
        event Action disconnectPortAction;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system default port.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected DSDefaultPort(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type)
            : base(portOrientation, portDirection, portCapacity, type)
        {
            disconnectPortAction = null;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <inheritdoc />
        public override void ConnectedEdgeLoadedAction(Edge edge)
        {
            DSDefaultEdgeCallbacks.Register(edge);
        }


        // ----------------------------- Maker -----------------------------
        /// <summary>
        /// Factory method for creating a new default input port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="portName">The name of the port, it'll appear next to the port if the value is not empty.</param>
        /// <param name="capacity">The type that determines how many edges a port can have for connections.</param>
        /// <returns>An input port that can connect to another node or nodes if capacity is set to multiple.</returns>
        public static DSDefaultPort GetNewInputPort<TEdge>(DSNodeBase node, string portName, Capacity capacity)
            where TEdge : Edge, new()
        {
            DSDefaultPort newInputPort;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            SetupDisconnectPortAction();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newInputPort;

            void CreateNewInstance()
            {
                newInputPort = new DSDefaultPort(Orientation.Horizontal, Direction.Input, capacity, typeof(float));
            }

            void SetupDetail()
            {
                newInputPort.name = Guid.NewGuid().ToString();
                newInputPort.portName = portName;
                newInputPort.portColor = DSPortColorsConfig.DefaultDSPortColor;

            }

            void SetupEdgeConnector()
            {
                // Default edge connector listener.
                newInputPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DSDefaultEdgeConnectorListener(node.GraphView.NodeCreationConnectorWindow)
                );

                newInputPort.AddManipulator(newInputPort.m_EdgeConnector);
            }

            void SetupDisconnectPortAction()
            {
                if (capacity == Capacity.Single)
                {
                    newInputPort.disconnectPortAction
                        = ()
                        => node.GraphView.DisconnectPort(newInputPort);
                }
                else
                {
                    newInputPort.disconnectPortAction
                        = ()
                        => node.GraphView.DisconnectPortMulti(newInputPort);
                }
            }

            void AddPortToContainer()
            {
                node.inputContainer.Add(newInputPort);
            }

            void AddStyleSheet()
            {
                newInputPort.styleSheets.Add(DSStylesConfig.DSPortsStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override defualt picking mode.
                newInputPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newInputPort.m_ConnectorBox.name = "";
                newInputPort.m_ConnectorText.name = "";
                newInputPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                newInputPort.AddToClassList(DSStylesConfig.Default_Input_Port);
                newInputPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Default_Input_Connector);
                newInputPort.m_ConnectorText.AddToClassList(DSStylesConfig.Default_Input_Label);
                newInputPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Default_Input_Cap);
            }
        }


        /// <summary>
        /// Factory method for creating a new default output port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="isSiblings">Is the port a sibing to the first ouput port within the same hierarchy.</param>
        /// <param name="portName">The name of the port, it'll appear next to the port if the value is not empty.</param>
        /// <param name="capacity">The type that determines how many edges a port can have for connections.</param>
        /// <returns>An output port that can connect to another node or nodes if capacity is set to multiple.</returns>
        public static DSDefaultPort GetNewOutputPort<TEdge>(DSNodeBase node, bool isSiblings, string portName, Capacity capacity)
            where TEdge : Edge, new()
        {
            DSDefaultPort newOutputPort;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            SetupDisconnectPortAction();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newOutputPort;

            void CreateNewInstance()
            {
                newOutputPort = new DSDefaultPort(Orientation.Horizontal, Direction.Output, capacity, typeof(float));
            }

            void SetupDetail()
            {
                newOutputPort.name = Guid.NewGuid().ToString();
                newOutputPort.portName = portName;
                newOutputPort.portColor = DSPortColorsConfig.DefaultDSPortColor;
            }

            void SetupEdgeConnector()
            {
                // Default edge connector listener.
                newOutputPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DSDefaultEdgeConnectorListener(node.GraphView.NodeCreationConnectorWindow)
                );

                newOutputPort.AddManipulator(newOutputPort.m_EdgeConnector);
            }

            void SetupDisconnectPortAction()
            {
                if (capacity == Capacity.Single)
                {
                    newOutputPort.disconnectPortAction
                        = ()
                        => node.GraphView.DisconnectPort(newOutputPort);
                }
                else
                {
                    newOutputPort.disconnectPortAction
                        = ()
                        => node.GraphView.DisconnectPortMulti(newOutputPort);
                }
            }

            void AddPortToContainer()
            {
                node.outputContainer.Add(newOutputPort);
            }

            void AddStyleSheet()
            {
                newOutputPort.styleSheets.Add(DSStylesConfig.DSPortsStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override defualt picking mode.
                newOutputPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newOutputPort.m_ConnectorBox.name = "";
                newOutputPort.m_ConnectorText.name = "";
                newOutputPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                newOutputPort.AddToClassList(DSStylesConfig.Default_Output_Port);
                newOutputPort.m_ConnectorBox.AddToClassList(DSStylesConfig.Default_Output_Connector);
                newOutputPort.m_ConnectorText.AddToClassList(DSStylesConfig.Default_Output_Label);
                newOutputPort.m_ConnectorBoxCap.AddToClassList(DSStylesConfig.Default_Output_Cap);

                // If the port is a sibling to another port within the same output container
                if (isSiblings)
                {
                    // Add an extra sibling style.
                    newOutputPort.AddToClassList(DSStylesConfig.Default_Port_Sibling);
                }
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that called when the connecting node is going to be deleted by users from the graph manually.
        /// </summary>
        public void NodePreManualRemovedAction() => DisconnectPort();


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <summary>
        /// Methods for adding menu items to the connecting node's contextual menu, 
        /// <br>items are added at the end of the current item list.</br>
        /// <para>This method is used inside the node's DSNodeFrameBase class, "BuildContextualManu" method.</para>
        /// </summary>
        /// <param name="evt">The event holding the connecting node's contextual menu to populate.</param>
        /// <param name="itemName">The name to use when it's shown on the menu.</param>
        public void AddContextualManuItems(ContextualMenuPopulateEvent evt, string itemName)
        {
            AppendDisconnectPortAction();

            void AppendDisconnectPortAction()
            {
                // Disconnect Port
                evt.menu.AppendAction
                (
                    // Menu item name.
                    itemName,
                    // Menu item action.
                    actionEvent => disconnectPortAction.Invoke(),
                    // Menu item status.
                    connected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );
            }
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect the port from its current opponent port.
        /// </summary>
        public void DisconnectPort()
        {
            if (connected)
            {
                disconnectPortAction.Invoke();
            }
        }
    }
}