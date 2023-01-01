using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionWindowNodePresenter : NodePresenterFrameBase
    <
        OptionWindowNode,
        OptionWindowNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionWindowNodePresenter(OptionWindowNode node, OptionWindowNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_NewOutputMultiOptionChannel();

            AddOutputSingleOptionChannel();

            AddHeaderTextContainer();

            void AddContentButton_NewOutputMultiOptionChannel()
            {
                ButtonFactory.CreateNewContentButton
                (
                    node: Node,
                    buttonText: StringsConfig.AddEntryLabelText,
                    buttonIconSprite: AssetsConfig.AddChoiceEntryButtonIconSprite,
                    buttonClickAction: ContentButtonClickedAction,
                    buttonIconUSS01: StylesConfig.Integrant_ContentButton_AddEntry_Image
                );
            }

            void AddOutputSingleOptionChannel()
            {
                Model.OutputSingleOptionChannel.SetupChannel(Node);
            }

            void AddHeaderTextContainer()
            {
                Node.mainContainer.Add(LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.HeaderTextContainer,
                    fieldIcon: AssetsConfig.HeadlineTextFieldIconSprite,
                    isMultiLine: false,
                    placeholderText: StringsConfig.OptionWindowNodeHeadlinePlaceholderText,
                    fieldUSS01: StylesConfig.OptionWindowNode_Header_TextField
                ));
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                portlabel: StringsConfig.NodeInputLabelText,
                isSiblings: false
            );

            // Refresh ports.
            Node.RefreshPorts();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the content button is clicked.
        /// <para>See: <see cref="CreateNodeElements"/></para>
        /// </summary>
        void ContentButtonClickedAction()
        {
            // Create a new output multi option channel.
            Model.OutputMultiOptionChannelGroup.GetNewChannel(data: null);

            // Update ports layout.
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectInputPortAction();

            AppendDisconnectOutputSingleOptionChannelAction();

            AppendDisconnectOutputMultiOptionChannelGroupAction();

            AppendDisconnectAllPortsAction();

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectOutputSingleOptionChannelAction()
            {
                Model.OutputSingleOptionChannel.AddContextualManuItems(evt);
            }

            void AppendDisconnectOutputMultiOptionChannelGroupAction()
            {
                Model.OutputMultiOptionChannelGroup.AddContextualManuItems(evt);
            }

            void AppendDisconnectAllPortsAction()
            {
                var isInputPortConnected = Model.InputPort.connected;
                var isOutputSingleOptionChannelConnected = Model.OutputSingleOptionChannel.Port.connected;
                var isOutputMultiOptionChannelGroupConnected = Model.OutputMultiOptionChannelGroup.IsConnectedChannelExists();

                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isOutputSingleOptionChannelConnected || isOutputMultiOptionChannelGroupConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect input port.
                    Model.InputPort.DisconnectPort();

                    // Disconnect output single option channel port.
                    Model.OutputSingleOptionChannel.DisconnectPort();

                    // Disconnect output multi option channel group's channels' port.
                    Model.OutputMultiOptionChannelGroup.DisconnectPorts();
                }
            }
        }


        // ----------------------------- Post Process Position Details Services -----------------------------
        /// <inheritdoc />
        protected override void PostProcessPositionDetails(NodeCreationDetails details)
        {
            CheckIsOptionChannelCreation();

            ShowNodeOnGraph();

            void CheckIsOptionChannelCreation()
            {
                if (details.ConnectorType == P_ConnectorType.OptionChannel)
                {
                    Model.OutputSingleOptionChannel.PostProcessPositionDetails(
                        opponentChannelPort: details.ConnectorPort
                    );
                }
                else
                {
                    AlignConnectorPosition();

                    ConnectConnectorPort();
                }
            }

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (details.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Middle:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;

                        break;
                    case C_Alignment_HorizontalType.Right:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;
                        break;
                }

                // Apply the final position result to the node.
                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connnector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                // Create local reference for the connector port.
                Port connectorPort = details.ConnectorPort;

                // If the connector port is connecting to another port, disconnect them first.
                if (connectorPort.connected)
                {
                    Node.GraphViewer.DisconnectPort(port: connectorPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge = Node.GraphViewer.ConnectPorts
                            (
                                outputPort: connectorPort,
                                inputPort: Model.InputPort
                            );

                // Register default edge callbacks to the edge.
                DefaultEdgeCallbacks.Register(edge: edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }
    }
}