using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class MultiOptionChannelGroup
    {
        /// <summary>
        /// The cached channel list.
        /// </summary>
        List<MultiOptionChannel> channels;

        /// <summary>
        /// The cached channel count.
        /// </summary>
        int channelsCount;


        /// <summary>
        /// Reference of the connecting node component.
        /// </summary>
        NodeBase node;


        /// <summary>
        /// Is this group contains output channels or input channels?
        /// </summary>
        bool isOutput;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the multi option channel group component class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        /// <param name="isOutput">The isOutput value to set for..</param>
        public MultiOptionChannelGroup(NodeBase node, bool isOutput)
        {
            this.node = node;
            this.isOutput = isOutput;

            channels = new();
            channelsCount = 0;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new option channel within the group.
        /// </summary>
        /// <param name="data">The given multi option channel data to load from.</param>
        public void GetNewChannel(MultiOptionChannelData data)
        {
            MultiOptionChannel newChannel;

            CreateNewChannel();

            CreateChannelPort();

            ChannelAddedAction();

            void CreateNewChannel()
            {
                newChannel = new(isOutput: isOutput);
            }

            void CreateChannelPort()
            {
                OptionPort.CreateInstanceElements<Edge>
                (
                    node: node,
                    channel: newChannel,
                    data: data,
                    removeButtonClickAction: () => RemoveChannelAction(newChannel)
                );
            }

            void ChannelAddedAction()
            {
                // Add the new channel's port to the serialize cache.
                node.GraphViewer.SerializeHandler.AddCachePort(port: newChannel.Port);

                // Add the channel to the group.
                channels.Add(newChannel);

                // Increase the channel count.
                channelsCount++;

                // Assign the channel group style to the node ouput container for the first channel added.
                if (channelsCount == 1){
                    ShowChannelGroupStyle();
                }
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Remove the given channel from the group.
        /// </summary>
        /// <param name="channel">The channel to remove.</param>
        private void RemoveChannelAction(MultiOptionChannel channel)
        {
            RemoveChannelFromList();

            RemoveChannelPort();

            UpdateGroupChannelsLabel();

            UpdateGroupStyle();

            void RemoveChannelFromList()
            {
                // Remove the channel from the group.
                channels.Remove(channel);

                // Decrease the channel count.
                channelsCount--;
            }

            void RemoveChannelPort()
            {
                OptionPort port = channel.Port;

                // If the channel is connecting.
                if (port.connected)
                {
                    // Hide the opponent channel port's connected style.
                    if (isOutput)
                    {
                        OptionChannelHelper.HideConnectedStyleInput(
                            inputPort: port.OpponentPort
                        );
                    }
                    else
                    {
                        OptionChannelHelper.HideConnectedStyleOutput(
                            outputPort: port.OpponentPort
                        );
                    }

                    // Disconnect them.
                    node.GraphViewer.DisconnectPort(port: port);
                }

                // Remove from node output container.
                node.DeletePortElement
                (
                    port: port,
                    directionType: Direction.Output
                );

                // Remove from the serialize cache.
                node.GraphViewer.SerializeHandler.RemoveCachePort(port: channel.Port);
            }

            void UpdateGroupChannelsLabel()
            {
                if (!isOutput)
                    return;

                // Check the internal channels
                for (int i = 0; i < channelsCount; i++)
                {
                    // If any of the channel is connecting.
                    if (channels[i].Port.connected)
                    {
                        // Retrieve its port reference.
                        OptionPort port = channels[i].Port;

                        // Get the port's sibiling index in string.
                        string sibilingIndexText =
                            port.GetSiblingIndexAdd(addByNumber: 1)
                            .ToString();

                        // Update the channel's label.
                        port.portName = StringUtility.New
                        (
                            text01: StringsConfig.OptionChannelConnectedOutputLabelText,
                            text02: sibilingIndexText
                        )
                        .ToString();

                        // Update the channel's opponent port label.
                        port.OpponentPort.portName = StringUtility.New
                        (
                            text01: StringsConfig.OptionChannelConnectedInputLabelText,
                            text02: sibilingIndexText
                        )
                        .ToString();
                    }
                }
            }

            void UpdateGroupStyle()
            {
                // Remove the channel group style from the node output container if there's no channels left.
                if (channelsCount == 0){
                    HideChannelGroupStyle();
                }
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the channel group values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to</param>
        public void SaveGroupValues(MultiOptionChannelGroupData data)
        {
            // Channels
            for (int i = 0; i < channelsCount; i++)
            {
                // New channel data.
                MultiOptionChannelData channelData = new();

                // Save values.
                channels[i].SaveChannelValues(channelData);
                
                // Add to list.
                data.ChannelDataList.Add(channelData);
            }

            // Channels count.
            data.ChannelDataListCount = channelsCount;
        }


        /// <summary>
        /// Load the channel group values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadGroupValues(MultiOptionChannelGroupData data)
        {
            // Channels
            for (int i = 0; i < data.ChannelDataListCount; i++)
            {
                GetNewChannel(data.ChannelDataList[i]);
            }
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
            AppendDisconnectChannelsAction();

            void AppendDisconnectChannelsAction()
            {
                for (int i = 0; i < channelsCount; i++)
                {
                    // Cache the current channel's port reference.
                    var port = channels[i].Port;
                    if (port.connected)
                    {
                        evt.menu.AppendAction
                        (
                            // Menu item name.
                            actionName: ActionName(),

                            // Menu item action.
                            action: actionEvent => channels[i].DisconnectPort(node),

                            // Menu item status.
                            status: DropdownMenuAction.Status.Normal
                        );
                    }

                    string ActionName()
                    {
                        if (isOutput)
                        {
                            return port.connected
                                   ? StringUtility.New(
                                                      text01: StringsConfig.DisconnectOutputChannelLabelText,
                                                      text02: port.portName
                                                      )
                                                      .ToString()

                                   : StringsConfig.DisconnectOutputPortLabelText;
                        }
                        else
                        {
                            return port.connected
                                   ? StringUtility.New(
                                                      text01: StringsConfig.DisconnectInputChannelLabelText,
                                                      text02: port.portName
                                                      )
                                                      .ToString()

                                   : StringsConfig.DisconnectInputPortLabelText;
                        }
                    }
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
            var opponentPort = (OptionPort)opponentChannelPort;
            var firstPort = channels[0].Port;

            AlignConnectorPosition();

            DisconnectOpponentPortConnections();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = node.localBound.position;

                // Height offset.
                result.y -= (node.titleContainer.worldBound.height + firstPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / node.GraphViewer.scale;

                if (isOutput)
                {
                    // Width offset.
                    result.x -= node.localBound.width;
                }

                // Apply the final position result to the node.
                node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void DisconnectOpponentPortConnections()
            {
                // If the opponent port is connecting.
                if (opponentPort.connected)
                {
                    // Hide the another channel port's connected style.
                    if (isOutput)
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
                    node.GraphViewer.DisconnectPort(port: opponentPort);
                }
            }

            void ConnectConnectorPort()
            {
                // Connect the opponent port and retrieve the new edge created inbetween.
                Edge edge;
                if (isOutput)
                {
                    edge = node.GraphViewer.ConnectPorts
                    (
                        outputPort: firstPort,
                        inputPort: opponentPort
                    );
                }
                else
                {
                    edge = node.GraphViewer.ConnectPorts
                    (
                        outputPort: opponentPort,
                        inputPort: firstPort
                    );
                }

                // Show both ports' connected styles.
                OptionChannelHelper.ShowConnectedStyleBoth(targetEdge: edge);

                // Register channel edge callbacks to the edge.
                ChannelEdgeCallbacks.Register(channelEdge: edge);

                // Register previous opponent port references.
                firstPort.OpponentPort = opponentPort;
                opponentPort.OpponentPort = firstPort;
            }
        }


        // ----------------------------- Disconnect Ports Services -----------------------------
        /// <summary>
        /// Disconnect every internal channel's port element.
        /// </summary>
        public void DisconnectPorts()
        {
            for (int i = 0; i < channelsCount; i++)
            {
                // Disconnect the port if it's connecting.
                channels[i].DisconnectPort(node);
            }
        }


        // ----------------------------- Remove Cache Ports Services -----------------------------
        /// <summary>
        /// Remove every internal channel's port from serialize handler's cache.
        /// </summary>
        public void RemoveCachePorts()
        {
            for (int i = 0; i < channelsCount; i++)
            {
                node.GraphViewer.SerializeHandler.RemoveCachePort(port: channels[i].Port);
            }
        }


        // ----------------------------- Retrieve Is Connected Channel Exists Services -----------------------------
        /// <summary>
        /// Is there any channels within the group is connecting?
        /// </summary>
        /// <returns>Return true if there's one channel within the group is connecting.</returns>
        public bool IsConnectedChannelExists()
        {
            for (int i = 0; i < channelsCount; i++)
            {
                if (channels[i].Port.connected){
                    return true;
                }
            }

            return false;
        }


        // ----------------------------- Add / Remove Channel Group Style Tasks -----------------------------
        /// <summary>
        /// Add the channel group style to node output container.
        /// </summary>
        void ShowChannelGroupStyle() =>
            node.outputContainer.AddToClassList(StylesConfig.Node_Output_Container_Window);


        /// <summary>
        /// Remove the channel group style from node output container.
        /// </summary>
        void HideChannelGroupStyle() =>
            node.outputContainer.RemoveFromClassList(StylesConfig.Node_Output_Container_Window);
    }
}