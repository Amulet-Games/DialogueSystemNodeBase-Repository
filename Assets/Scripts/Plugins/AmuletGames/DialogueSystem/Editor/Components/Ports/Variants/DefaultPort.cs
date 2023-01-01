using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DefaultPort : PortBase
    {
        /// <summary>
        /// Action for disconnecting the port from its current opponent port.
        /// </summary>
        event Action disconnectPortAction;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the default port element class.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected DefaultPort
        (
            Orientation portOrientation,
            Direction portDirection,
            Capacity portCapacity,
            Type type
        )
            : base(portOrientation, portDirection, portCapacity, type)
        {
            disconnectPortAction = null;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void ConnectionLoadedAction(Edge edge)
        {
            // Register callbacks to the edge that the ports are connecting with.
            DefaultEdgeCallbacks.Register(edge);
        }


        // ----------------------------- Maker -----------------------------
        /// <summary>
        /// Factory method for creating a new root port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="node">Reference of the node element that the port belongs to.</param>
        /// <param name="direction">The direction type to set for, is it facing left or right.</param>
        /// <param name="capacity">The capacity type to set for, can it has multiple connections or only one.</param>
        /// <param name="portlabel">The port's label to set for, it displays next to the port.</param>
        /// <param name="isSiblings">The siblings property to set for, is the port's container allows to contain multiple ports?</param>
        /// <returns>A default port that can connect with other default ports in their node.</returns>
        public static DefaultPort CreateRootElements<TEdge>
        (
            NodeBase node,
            Direction direction,
            Capacity capacity,
            string portlabel,
            bool isSiblings
        )
            where TEdge : Edge, new()
        {
            DefaultPort newPort;
            bool isInput;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            SetupPortDisconnectedAction();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newPort;

            void CreateNewInstance()
            {
                newPort = new(
                                portOrientation: Orientation.Horizontal,
                                portDirection: direction,
                                portCapacity: capacity,
                                type: typeof(float)
                             );

                isInput = direction == Direction.Input;
            }

            void SetupDetail()
            {
                newPort.name = Guid.NewGuid().ToString();
                newPort.portName = portlabel;
                newPort.portColor = PortsConfig.DefaultPortColor;
            }

            void SetupEdgeConnector()
            {
                // Default edge connector listener.
                newPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DefaultEdgeConnectorListener
                    (
                        connectorWindow: node.GraphViewer.NodeCreationConnectorWindow
                    )
                );

                // Add the default edge connector as manipulator to the port.
                newPort.AddManipulator(manipulator: newPort.m_EdgeConnector);
            }

            void SetupPortDisconnectedAction()
            {
                newPort.disconnectPortAction = capacity == Capacity.Single
                    // Disconnect single port action.
                    ? () => node.GraphViewer.DisconnectPort(port: newPort)
                    // Register disconnect multi action. 
                    : () => node.GraphViewer.DisconnectPortMulti(port: newPort);
            }

            void AddPortToContainer()
            {
                if (isInput)
                    node.inputContainer.Add(newPort);
                else
                    node.outputContainer.Add(newPort);
            }

            void AddStyleSheet()
            {
                newPort.styleSheets.Add(StylesConfig.DSPortsStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Override defualt picking mode.
                newPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newPort.m_ConnectorBox.name = "";
                newPort.m_ConnectorText.name = "";
                newPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                if (isInput)
                {
                    newPort.AddToClassList(StylesConfig.Default_Input_Port);
                    newPort.m_ConnectorBox.AddToClassList(StylesConfig.Default_Input_Connector);
                    newPort.m_ConnectorText.AddToClassList(StylesConfig.Default_Input_Label);
                    newPort.m_ConnectorBoxCap.AddToClassList(StylesConfig.Default_Input_Cap);
                }
                else
                {
                    newPort.AddToClassList(StylesConfig.Default_Output_Port);
                    newPort.m_ConnectorBox.AddToClassList(StylesConfig.Default_Output_Connector);
                    newPort.m_ConnectorText.AddToClassList(StylesConfig.Default_Output_Label);
                    newPort.m_ConnectorBoxCap.AddToClassList(StylesConfig.Default_Output_Cap);
                }

                if (isSiblings)
                {
                    // Add to sibling class if the output container that port is in containing other ports.
                    newPort.AddToClassList(StylesConfig.Default_Port_Sibling);
                }
            }
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <summary>
        /// Methods for adding menu items to the connecting node's contextual menu, 
        /// <br>items are added at the end of the current item list.</br>
        /// <para>See: <see cref="NodeFrameBase{TNode, TNodeModel, TNodePresenter, TNodeSerializer, TNodeCallback, TNodeData}.BuildContextualMenu"/></para>
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
                    actionName: itemName,

                    // Menu item action.
                    action: actionEvent => DisconnectPort(),

                    // Menu item status.
                    status: connected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
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