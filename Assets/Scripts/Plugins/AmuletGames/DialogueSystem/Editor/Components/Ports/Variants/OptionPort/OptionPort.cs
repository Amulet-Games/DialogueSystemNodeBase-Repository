using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class OptionPort : PortBase
    {
        /// <summary>
        /// The opponent option port that it's connecting to.
        /// <br>Its updated each time the port connects to a new opponent port.</br>
        /// </summary>
        public OptionPort OpponentPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option port element class.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected OptionPort
        (
            Orientation portOrientation,
            Direction portDirection,
            Capacity portCapacity,
            Type type
        )
            : base(portOrientation, portDirection, portCapacity, type)
        {
            OpponentPort = null;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <inheritdoc />
        public override void ConnectionLoadedAction(Edge edge)
        {
            // Get all the necessary references.
            OptionPort opponentInputPort = (OptionPort)edge.input;

            // Add connected USS style class to the internal port and opponent input port.
            OptionChannelHelper.AddConnectedClassOutput(outputPort: this);
            OptionChannelHelper.AddConnectedClassInput(inputPort: opponentInputPort);

            // Register callbacks to the edge that the ports are connecting with.
            ChannelEdgeCallbacks.Register(edge);

            // Register previous opponent port references to both the internal port and opponent input port.
            OpponentPort = opponentInputPort;
            opponentInputPort.OpponentPort = this;
        }


        // ----------------------------- Maker -----------------------------
        /// <summary>
        /// Factory method for creating a new root option port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="channel">The channel that this port is created for.</param>
        public static void CreateRootElements<TEdge>(SingleOptionChannel channel)
            where TEdge : Edge, new()
        {
            OptionPort newPort;
            NodeBase node = channel.Node;
            bool isOuput = channel.IsOutput;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            void CreateNewInstance()
            {
                newPort = new(
                                portOrientation: Orientation.Horizontal,
                                portDirection: isOuput ? Direction.Output : Direction.Input,
                                portCapacity: Capacity.Single,
                                type: typeof(float)
                             );

                channel.Port = newPort;
            }

            void SetupDetail()
            {
                // Port GUID
                newPort.name = Guid.NewGuid().ToString();

                // Port label
                newPort.portName = isOuput
                                   ? StringsConfig.OptionChannelEmptyOutputLabelText
                                   : StringsConfig.OptionChannelEmptyInputLabelText;

                // Port color
                newPort.portColor = PortsConfig.OptionChannelPortColor;
            }

            void SetupEdgeConnector()
            {
                // Channel edge connector listener.
                newPort.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new ChannelEdgeConnectorListener
                    (
                        owner: newPort,
                        connectorWindow: node.GraphViewer.NodeCreationConnectorWindow
                    )
                );

                // Add the channel edge connector as manipulator to the port.
                newPort.AddManipulator(manipulator: newPort.m_EdgeConnector);
            }

            void AddPortToContainer()
            {
                if (isOuput)
                    node.outputContainer.Add(newPort);
                else
                    node.inputContainer.Add(newPort);
            }

            void AddStyleSheet()
            {
                newPort.styleSheets.Add
                (
                    isOuput ? StylesConfig.DSOutputOptionChannelsStyle
                            : StylesConfig.DSInputOptionChannelsStyle
                );
            }

            void OverridePortDefaultStyle()
            {
                // Override the cap's defualt picking mode.
                newPort.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                newPort.m_ConnectorBox.name = "";
                newPort.m_ConnectorText.name = "";
                newPort.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                if (isOuput)
                {
                    newPort.AddToClassList(StylesConfig.Channel_Option_Output_Port);
                    newPort.m_ConnectorBox.AddToClassList(StylesConfig.Channel_Option_Output_Connector);
                    newPort.m_ConnectorText.AddToClassList(StylesConfig.Channel_Option_Output_Label);
                    newPort.m_ConnectorBoxCap.AddToClassList(StylesConfig.Channel_Option_Output_Cap);
                }
                else
                {
                    newPort.AddToClassList(StylesConfig.Channel_Option_Input_Port);
                    newPort.m_ConnectorBox.AddToClassList(StylesConfig.Channel_Option_Input_Connector);
                    newPort.m_ConnectorText.AddToClassList(StylesConfig.Channel_Option_Input_Label);
                    newPort.m_ConnectorBoxCap.AddToClassList(StylesConfig.Channel_Option_Input_Cap);
                }
            }
        }


        // ----------------------------- Hide Opponent Connected Style Services -----------------------------
        /// <summary>
        /// Hide the opponent port's connected style if it's not connecting to other option port. 
        /// </summary>
        /// <param name="isOutput">Is the opponent channel's port direction is output or input.</param>
        public void HideConnectedStyleOpponent(bool isOutput)
        {
            // If the owner is connecting to a opponent port
            if (OpponentPort != null && !OpponentPort.connected)
            {
                if (isOutput)
                {
                    OptionChannelHelper.HideConnectedStyleOutput
                    (
                        outputPort: OpponentPort
                    );
                }
                else
                {
                    OptionChannelHelper.HideConnectedStyleInput
                    (
                        inputPort: OpponentPort
                    );
                }
            }
        }
    }
}