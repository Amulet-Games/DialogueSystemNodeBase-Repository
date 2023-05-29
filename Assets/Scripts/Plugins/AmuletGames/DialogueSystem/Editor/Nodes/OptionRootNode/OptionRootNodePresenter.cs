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
        /// Constructor of the option root node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
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
                var contentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.Instance.SpriteConfig.AddEntryButtonIconSprite
                );

                //new ContentButtonCallback(
                //    isAlert: true,
                //    contentButton: contentButton,
                //    clickEvent: ContentButtonClickEvent).RegisterEvents();

                Node.titleContainer.Add(contentButton);
            }

            void SetupOptionRootGroup()
            {
                VisualElement mainContainer;
                VisualElement outerContainer;
                VisualElement InnerContainer;

                Image rootIconImage;
                Label rootTitleLabel;

                SetupContainers();

                SetupOptionRootIconImage();

                SetupOptionRootTitleLabel();

                SetupOptionRootTitleTextField();

                AddElementsToContainer();

                AddContainersToNode();

                void SetupContainers()
                {
                    mainContainer = new();
                    mainContainer.AddToClassList(StyleConfig.Instance.OptionRootNode_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.Instance.OptionRootNode_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.Instance.OptionRootNodeInnerContainer);
                }

                void SetupOptionRootIconImage()
                {
                    rootIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.Instance.SpriteConfig.OptionRootIconSprite,
                        imageUSS01: StyleConfig.Instance.OptionRootNode_Icon_Image
                    );
                }

                void SetupOptionRootTitleLabel()
                {
                    rootTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                        labelUSS01: StyleConfig.Instance.OptionRootNode_Title_Label
                    );
                }

                void SetupOptionRootTitleTextField()
                {
                    Model.RootTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElement
                        (
                            isMultiLine: false,
                            placeholderText: Model.RootTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.Instance.OptionRootNode_Title_TextField
                        );

                    //new LanguageTextFieldCallback(
                    //    model: Model.RootTitleTextFieldModel).RegisterEvents();
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(rootIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(rootTitleLabel);
                    InnerContainer.Add(Model.RootTitleTextFieldModel.TextField);
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
            Model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            Model.OutputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.OutputOptionPort);
            Node.RefreshPorts();
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