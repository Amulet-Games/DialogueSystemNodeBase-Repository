using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodePresenter : NodePresenterFrameBase
    <
        OptionTrackNode,
        OptionTrackNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionTrackNodePresenter(OptionTrackNode node, OptionTrackNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_ConditionModifier();

            AddInputSingleOptionChannel();

            AddHeaderTextContainer();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                ButtonFactory.CreateNewContentButton
                (
                    node: Node,
                    buttonText: StringsConfig.AddConditionLabelText,
                    buttonIconSprite: AssetsConfig.AddConditionModifierButtonIconSprite,
                    buttonClickAction: ContentButtonClickedAction,
                    buttonIconUSS01: StylesConfig.Integrant_ContentButton_AddCondition_Image
                );
            }

            void AddInputSingleOptionChannel()
            {
                Model.InputSingleOptionChannel.SetupChannel(Node);
            }

            void AddHeaderTextContainer()
            {
                Node.mainContainer.Add(LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.HeaderTextContainer,
                    fieldIcon: AssetsConfig.HeadlineTextFieldIconSprite,
                    isMultiLine: false,
                    placeholderText: StringsConfig.OptionTrackNodeHeadlinePlaceholderText,
                    fieldUSS01: StylesConfig.OptionTrackNode_Header_TextField
                ));
            }

            void AddConditionSegment()
            {
                Model.ConditionSegment.CreateRootElements(Node);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Output port.
            Model.OutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeOutputLabelText,
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
            // Create a new condition modifier within this node.
            new ConditionModifier().CreateInstanceElements
            (
                data: null,
                modifierCreatedAction: Model.ConditionSegment.ModifierCreatedAction,
                removeButtonClickAction: Model.ConditionSegment.ModifierRemoveButtonClickAction
            );

            // Reveal the condition segment on the connecting node.
            VisualElementHelper.ShowElement(Model.ConditionSegment.MainBox);
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectInputSingleOptionChannelAction();

            AppendDisconnectOutputPortAction();

            AppendDisconnectAllPortsAction();

            void AppendDisconnectInputSingleOptionChannelAction()
            {
                Model.InputSingleOptionChannel.AddContextualManuItems(evt);
            }

            void AppendDisconnectOutputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                var isInputSingleOptionChannelConnected = Model.InputSingleOptionChannel.Port.connected;
                var isOutputPortConnected = Model.OutputPort.connected;

                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputSingleOptionChannelConnected || isOutputPortConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect input single option channel port.
                    Model.InputSingleOptionChannel.DisconnectPort();

                    // Disconnect Output port.
                    Model.OutputPort.DisconnectPort();
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
                    Model.InputSingleOptionChannel.PostProcessPositionDetails(
                        opponentChannelPort: details.ConnectorPort
                    );
                }
                else
                {
                    AlignConnectorPosition();

                    ConnectConnectorPort();
                }

                void AlignConnectorPosition()
                {
                    // Create a new vector2 result variable to cache the node's current local bound position.
                    Vector2 result = Node.localBound.position;

                    switch (details.HorizontalAlignType)
                    {
                        case C_Alignment_HorizontalType.Left:

                            // Height offset.
                            result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                            // Width offset.
                            result.x -= Node.localBound.width;

                            break;
                        case C_Alignment_HorizontalType.Middle:

                            // Height offset.
                            result.y -= (Node.titleContainer.worldBound.height + Model.InputSingleOptionChannel.Port.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                            // Width offset.
                            result.x -= Node.localBound.width / 2;
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
                                    outputPort: Model.OutputPort,
                                    inputPort: connectorPort
                                );

                    // Register default edge callbacks to the edge.
                    DefaultEdgeCallbacks.Register(edge: edge);
                }
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }
    }
}