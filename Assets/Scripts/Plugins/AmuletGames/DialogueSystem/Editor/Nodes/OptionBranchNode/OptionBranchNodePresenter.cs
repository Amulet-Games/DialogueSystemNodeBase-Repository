using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodePresenter : NodePresenterFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public OptionBranchNodePresenter(OptionBranchNode node, OptionBranchNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            SetupContentButton();

            SetupOptionBranchGroup();

            void SetupContentButton()
            {
                var contentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.Instance.SpriteConfig.AddConditionModifierButtonIconSprite
                );

                new ContentButtonCallback(
                    isAlert: true,
                    contentButton: contentButton,
                    clickEvent: ContentButtonClickEvent).RegisterEvents();

                Node.titleContainer.Add(contentButton);
            }

            void SetupOptionBranchGroup()
            {
                VisualElement mainContainer;
                VisualElement outerContainer;
                VisualElement InnerContainer;

                Image optionBranchIconImage;
                Label optionBranchTitleLabel;

                SetupContainers();

                SetupOptionBranchIconImage();

                SetupOptionBranchTitleLabel();

                SetupOptionBranchTitleTextField();

                AddElementsToContainer();

                AddContainersToNode();

                void SetupContainers()
                {
                    mainContainer = new();
                    mainContainer.AddToClassList(StyleConfig.Instance.OptionBranchGroup_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.Instance.OptionBranchGroup_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.Instance.OptionBranchGroup_InnerContainer);
                }

                void SetupOptionBranchIconImage()
                {
                    optionBranchIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.Instance.SpriteConfig.OptionBranchIconSprite,
                        imageUSS01: StyleConfig.Instance.OptionBranchGroup_Icon_Image
                    );
                }

                void SetupOptionBranchTitleLabel()
                {
                    optionBranchTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.Instance.OptionBranchGroup_TitleLabelText,
                        labelUSS01: StyleConfig.Instance.OptionBranchGroup_Title_Label
                    );
                }

                void SetupOptionBranchTitleTextField()
                {
                    Model.OptionBranchTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElement
                        (
                            isMultiLine: false,
                            placeholderText: Model.OptionBranchTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.Instance.OptionBranchGroup_Title_TextField
                        );

                    new LanguageTextFieldCallback(
                        model: Model.OptionBranchTitleTextFieldModel).RegisterEvents();
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(optionBranchIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(optionBranchTitleLabel);
                    InnerContainer.Add(Model.OptionBranchTitleTextFieldModel.TextField);
                }

                void AddContainersToNode()
                {
                    Node.ContentContainer.Add(mainContainer);
                }
            }

            void AddOptionBranchNodeStitcher()
            {
                // Create all the root elements required in the node stitcher.
                Model.OptionBranchNodeStitcher.CreateRootElements(Node);
            }
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input
            );

            Model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Output_LabelText
            );

            Node.Add(Model.InputOptionPort);
            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        void ContentButtonClickEvent(ClickEvent evt)
        {
            // Release the focus of the node's border.
            Node.NodeBorder.Blur();

            // Add a new instance modifier to the node.
            Model.OptionBranchNodeStitcher.AddInstanceModifier(data: null);
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var optionInput = Model.InputOptionPort;
            var defaultOutput = Model.OutputDefaultPort;

            // Disconnect Option Input
            evt.menu.AppendAction
            (
                actionName: optionInput.GetDisconnectPortContextualMenuItemLabel(),
                action: action => optionInput.Disconnect(Node.GraphViewer),
                status: optionInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectOutputPort_LabelText,
                action: action => defaultOutput.Disconnect(Node.GraphViewer),
                status: defaultOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            var isAnyConnected = optionInput.connected
                              || defaultOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    optionInput.Disconnect(Node.GraphViewer);

                    defaultOutput.Disconnect(Node.GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
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
                                  + Model.OutputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width;

                        break;
                    case HorizontalAlignmentType.MIDDLE:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputOptionPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width / 2;

                        break;
                    case HorizontalAlignmentType.RIGHT:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputOptionPort.localBound.position.y
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
                            output: Model.OutputDefaultPort,
                            input: (DefaultPort)port
                        );

                        break;
                    case ConnectorType.OPTION:

                        edge = EdgeManager.Instance.Connect
                        (
                            output: (OptionPort)port,
                            input: Model.InputOptionPort
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