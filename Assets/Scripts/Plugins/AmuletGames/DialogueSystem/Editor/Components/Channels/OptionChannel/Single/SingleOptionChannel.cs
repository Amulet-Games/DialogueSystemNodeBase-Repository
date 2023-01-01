using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class SingleOptionChannel
    {
        /// <summary>
        /// Reference of the connecting port component.
        /// </summary>
        [NonSerialized] public OptionPort Port;


        /// <summary>
        /// Reference of the connecting node component.
        /// </summary>
        [NonSerialized] public NodeBase Node;


        /// <summary>
        /// Is the channel contains output port or input port?
        /// </summary>
        [NonSerialized] public bool IsOutput;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the single option channel base class.
        /// </summary>
        /// <param name="isOutput">The isOutput value to set for.</param>
        public SingleOptionChannel(bool isOutput)
        {
            IsOutput = isOutput;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this channel.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public void SetupChannel(NodeBase node)
        {
            // Setup Ref.
            Node = node;

            // Create Port.
            OptionPort.CreateRootElements<Edge>(channel: this);
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the channel values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveChannelValues(SingleOptionChannelData data)
        {
            // Port GUID
            data.PortGUID = Port.name;

            // Port label
            data.PortLabel = Port.portName;
        }


        /// <summary>
        /// Load the channel values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadChannelValues(SingleOptionChannelData data)
        {
            // Port GUID
            Port.name = data.PortGUID;

            // Port label
            Port.portName = data.PortLabel;
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <summary>
        /// Methods for adding menu items to the connecting node's contextual menu, 
        /// <br>items are added at the end of the current item list.</br>
        /// <para>See: <see cref="NodeFrameBase{TNode, TNodeModel, TNodePresenter, TNodeSerializer, TNodeCallback, TNodeData}.BuildContextualMenu"/></para>
        /// </summary>
        /// <param name="evt">The event holding the connecting node's contextual menu to populate.</param>
        public void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectChannelAction();

            void AppendDisconnectChannelAction()
            {
                evt.menu.AppendAction
                (
                    // Menu item name.
                    actionName: ActionName(),

                    // Menu item action.
                    action: actionEvent => DisconnectPort(),

                    // Menu item status.
                    status: Port.connected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );
            }

            string ActionName()
            {
                if (IsOutput)
                {
                    return Port.connected
                           ? StringUtility.New(
                                              text01: StringsConfig.DisconnectOutputChannelLabelText,
                                              text02: Port.portName
                                              )
                                              .ToString()

                           : StringsConfig.DisconnectOutputPortLabelText;
                }
                else
                {
                    return Port.connected
                           ? StringUtility.New(
                                              text01: StringsConfig.DisconnectInputChannelLabelText,
                                              text02: Port.portName
                                              )
                                              .ToString()

                           : StringsConfig.DisconnectInputPortLabelText;
                }
            }
        }


        // ----------------------------- Post Process Position Details Services -----------------------------
        /// <summary>
        /// Set the connecting node's first position base on the creation details.
        /// </summary>
        /// <param name="opponentChannelPort">Reference of the opponent channel's port that created the drag and drop channel edge.</param>
        public void PostProcessPositionDetails(Port opponentChannelPort)
        {
            // Downcast the opponent channel port class from Port to OptionPort.
            var opponentPort = (OptionPort)opponentChannelPort;

            AlignConnectorPosition();

            DisconnectOpponentPortConnections();

            ConnectOpponentPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Port.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                if (IsOutput)
                {
                    // Width offset.
                    result.x -= Node.localBound.width;
                }

                // Apply the final position result to the node.
                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void DisconnectOpponentPortConnections()
            {
                // If the opponent is connecting.
                if (opponentPort.connected)
                {
                    // Hide the another channel port's connected style.
                    if (IsOutput)
                    {
                        OptionChannelHelper.HideConnectedStyleOutput(
                            outputPort: opponentPort.OpponentPort
                        );
                    }
                    else
                    {
                        OptionChannelHelper.HideConnectedStyleInput(
                            inputPort: opponentPort.OpponentPort
                        );
                    }

                    // Disconnect them.
                    Node.GraphViewer.DisconnectPort(port: opponentPort);
                }
            }

            void ConnectOpponentPort()
            {
                // Connect the opponent port and retrieve the new edge created inbetween.
                Edge edge;
                if (IsOutput)
                {
                    edge = Node.GraphViewer.ConnectPorts
                    (
                        outputPort: Port,
                        inputPort: opponentPort
                    );
                }
                else
                {
                    edge = Node.GraphViewer.ConnectPorts
                    (
                        outputPort: opponentPort,
                        inputPort: Port
                    );
                }


                // Show both ports' connected styles.
                OptionChannelHelper.ShowConnectedStyleBoth(targetEdge: edge);

                // Register channel edge callbacks to the edge.
                ChannelEdgeCallbacks.Register(channelEdge: edge);

                // Register previous opponent port references.
                Port.OpponentPort = opponentPort;
                opponentPort.OpponentPort = Port;
            }
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect the internal port element.
        /// </summary>
        public void DisconnectPort()
        {
            if (Port.connected)
            {
                // Hide both the internal and opponent port's connected style.
                if (IsOutput)
                {
                    OptionChannelHelper.HideConnectedStyleBoth(
                        inputPort: Port.OpponentPort,
                        outputPort: Port
                    );
                }
                else
                {
                    OptionChannelHelper.HideConnectedStyleBoth(
                        inputPort: Port,
                        outputPort: Port.OpponentPort
                    );
                }

                // Disconnect the ports.
                Node.GraphViewer.DisconnectPort(port: Port);
            }
        }
    }
}