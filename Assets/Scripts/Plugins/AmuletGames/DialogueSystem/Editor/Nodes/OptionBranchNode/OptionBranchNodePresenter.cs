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
                Model.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.Instance.SpriteConfig.AddConditionModifierButtonIconSprite
                );

                //new ContentButtonCallback(
                //    isAlert: true,
                //    contentButton: Model.OptionBranchContentButton,
                //    clickEvent: ContentButtonClickEvent).RegisterEvents();

                Node.titleContainer.Add(Model.ContentButton);
            }

            void SetupOptionBranchGroup()
            {
                VisualElement mainContainer;
                VisualElement outerContainer;
                VisualElement InnerContainer;

                Image branchIconImage;
                Label branchTitleLabel;

                SetupContainers();

                SetupBranchIconImage();

                SetupBranchTitleLabel();

                SetupBranchTitleTextField();

                AddElementsToContainer();

                AddContainersToNode();

                void SetupContainers()
                {
                    mainContainer = new();
                    mainContainer.AddToClassList(StyleConfig.Instance.OptionBranchNode_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.Instance.OptionBranchNode_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.Instance.OptionBranchNode_InnerContainer);
                }

                void SetupBranchIconImage()
                {
                    branchIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.Instance.SpriteConfig.OptionBranchIconSprite,
                        imageUSS01: StyleConfig.Instance.OptionBranchNode_Icon_Image
                    );
                }

                void SetupBranchTitleLabel()
                {
                    branchTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionBranchNode_BranchTitleLabel_LabelText,
                        labelUSS01: StyleConfig.Instance.OptionBranchNode_Title_Label
                    );
                }

                void SetupBranchTitleTextField()
                {
                    Model.BranchTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElement
                        (
                            isMultiLine: false,
                            placeholderText: Model.BranchTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.Instance.OptionBranchNode_Title_TextField
                        );

                    //new LanguageTextFieldCallback(
                    //    model: Model.BranchTitleTextFieldModel).RegisterEvents();
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(branchIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(branchTitleLabel);
                    InnerContainer.Add(Model.BranchTitleTextFieldModel.TextField);
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
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(Model.InputOptionPort);
            Node.Add(Model.OutputDefaultPort);
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