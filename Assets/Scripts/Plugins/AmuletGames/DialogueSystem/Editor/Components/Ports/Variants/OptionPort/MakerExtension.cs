using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class OptionPort : PortBase
    {
        /// <summary>
        /// Factory method for creating a new multi option channel port.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="node">Reference of the connecting node component of the channel that this port is created for.</param>
        /// <param name="channel">The channel that this port is created for.</param>
        /// <param name="data">The given multi option channel data to load from.</param>
        /// <param name="ChannelRemovedAction">The action to invoke when the channel remove button is pressed.</param>
        public static void CreateInstanceElements<TEdge>
        (
            NodeBase node,
            MultiOptionChannel channel,
            MultiOptionChannelData data,
            Action ChannelRemovedAction
        )
            where TEdge : Edge, new()
        {
            OptionPort newPort;
            bool isOutput = channel.IsOutput;

            CreateNewInstance();

            SetupDetail();

            SetupEdgeConnector();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            SetupRemoveChannelButton();

            void CreateNewInstance()
            {
                newPort = new OptionPort
                                (
                                    portOrientation: Orientation.Horizontal,
                                    portDirection: isOutput ? Direction.Output : Direction.Input,
                                    portCapacity: Capacity.Single,
                                    type: typeof(float)
                                );

                channel.Port = newPort;
            }

            void SetupDetail()
            {
                // Port GUID
                newPort.name = data == null
                    ? Guid.NewGuid().ToString()
                    : data.PortGUID;

                // Port label
                newPort.portName = data == null
                    ? StringsConfig.OptionChannelEmptyOutputLabelText
                    : data.PortLabel;
                
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
                if (isOutput)
                    node.outputContainer.Add(newPort);
                else
                    node.inputContainer.Add(newPort);
            }

            void AddStyleSheet()
            {
                newPort.styleSheets.Add
                (
                    isOutput ? StylesConfig.DSOutputOptionChannelsStyle
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
                if (isOutput)
                {
                    newPort.AddToClassList(StylesConfig.Channel_Option_Group_Output_Port);
                    newPort.m_ConnectorBox.AddToClassList(StylesConfig.Channel_Option_Output_Connector);
                    newPort.m_ConnectorText.AddToClassList(StylesConfig.Channel_Option_Group_Output_Label);
                    newPort.m_ConnectorBoxCap.AddToClassList(StylesConfig.Channel_Option_Output_Cap);
                }
            }

            void SetupRemoveChannelButton()
            {
                // Get a new channel remove button.
                var channelRemoveButton =
                    ChannelFactory.CreateRemoveChannelButton(action: ChannelRemovedAction);

                // Add it to the port's container.
                newPort.contentContainer.Add(channelRemoveButton);
            }
        }
    }
}