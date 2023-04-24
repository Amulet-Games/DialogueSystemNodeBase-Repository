using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodePresenter : NodePresenterFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node presenter module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public OptionRootNodePresenter(OptionRootNode node, OptionRootNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            SetupContentButton();

            SetupOptionRootGroup();

            void SetupContentButton()
            {
                var contentButton = ContentButtonPresenter.CreateElements
                (
                    buttonText: StringConfig.Instance.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.Instance.SpriteConfig.AddEntryButtonIconSprite
                );

                new ContentButtonCallback(
                    isAlert: true,
                    contentButton: contentButton,
                    clickEvent: ContentButtonClickEvent).RegisterEvents();

                Node.titleContainer.Add(contentButton);
            }

            void SetupOptionRootGroup()
            {
                VisualElement mainContainer;
                VisualElement outerContainer;
                VisualElement InnerContainer;

                Image optionRootIconImage;
                Label optionRootTitleLabel;

                SetupContainers();

                SetupOptionRootIconImage();

                SetupOptionRootTitleLabel();

                SetupOptionRootTitleTextField();

                AddElementsToContainer();

                AddContainersToNode();

                void SetupContainers()
                {
                    mainContainer = new();
                    mainContainer.AddToClassList(StyleConfig.Instance.OptionRootGroup_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.Instance.OptionRootGroup_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.Instance.OptionRootGroup_InnerContainer);
                }

                void SetupOptionRootIconImage()
                {
                    optionRootIconImage = CommonImagePresenter.CreateElements
                    (
                        imageSprite: ConfigResourcesManager.Instance.SpriteConfig.OptionRootIconSprite,
                        imageUSS01: StyleConfig.Instance.OptionRootGroup_Icon_Image
                    );
                }

                void SetupOptionRootTitleLabel()
                {
                    optionRootTitleLabel = CommonLabelPresenter.CreateElements
                    (
                        labelText: StringConfig.Instance.OptionRootGroup_TitleLabelText,
                        labelUSS01: StyleConfig.Instance.OptionRootGroup_Title_Label
                    );
                }

                void SetupOptionRootTitleTextField()
                {
                    Model.OptionRootTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElements
                        (
                            isMultiLine: false,
                            placeholderText: Model.OptionRootTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.Instance.OptionRootGroup_Title_TextField
                        );

                    new LanguageTextFieldCallback(
                        model: Model.OptionRootTitleTextFieldModel).RegisterEvents();
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(optionRootIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(optionRootTitleLabel);
                    InnerContainer.Add(Model.OptionRootTitleTextFieldModel.TextField);
                }

                void AddContainersToNode()
                {
                    Node.ContentContainer.Add(mainContainer);
                }
            }
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                label: StringConfig.Instance.DefaultPort_Input_LabelText
            );

            Model.OutputOptionPort = OptionPort.CreateElements<OptionEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Output
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.OutputOptionPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        public void ContentButtonClickEvent(ClickEvent evt)
        {
            // Release the focus of the node's border.
            Node.NodeBorder.Blur();

            // Create a new output multi option channel.
            Model.OutputOptionPortGroupModel.AddCell(Node);

            // Update ports layout.
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var optionOutput = Model.OutputOptionPort;
            var optionGroupOutput = Model.OutputOptionPortGroupModel;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(Node.GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Option Output
            evt.menu.AppendAction
            (
                actionName: optionOutput.GetDisconnectPortContextualMenuItemLabel(),
                action: action => optionOutput.Disconnect(Node.GraphViewer),
                status: optionOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Option Output Group
            optionGroupOutput.AddContextualMenuItems(Node.GraphViewer, evt);

            // Disconnect All
            var isAnyConnected = defaultInput.connected
                              || optionOutput.connected
                              || optionGroupOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(Node.GraphViewer);

                    optionOutput.Disconnect(Node.GraphViewer);

                    optionGroupOutput.Disconnect(Node.GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void PostProcessPositionDetails(NodeCreationDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            void AlignConnectorPosition()
            {
                Vector2 result = Node.localBound.position;

                switch (details.HorizontalAlignmentType)
                {
                    case HorizontalAlignmentType.LEFT:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.OutputOptionPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width;

                        break;
                    case HorizontalAlignmentType.MIDDLE:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width / 2;

                        break;
                    case HorizontalAlignmentType.RIGHT:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        break;
                }

                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                var port = details.ConnectorPort;
                if (port.connected)
                {
                    port.Disconnect(Node.GraphViewer);
                }

                EdgeBase edge = null;
                switch (details.ConnectorType)
                {
                    case ConnectorType.DEFAULT:

                        edge = EdgeManager.Instance.Connect
                        (
                            output: (DefaultPort)port,
                            input: Model.InputDefaultPort
                        );

                        break;
                    case ConnectorType.OPTION:

                        edge = EdgeManager.Instance.Connect
                        (
                            output: Model.OutputOptionPort,
                            input: (OptionPort)port
                        );
                        break;
                }

                Node.GraphViewer.Add(edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StyleConfig.Instance.Global_Visible_Hidden);
            }
        }
    }
}