using UnityEditor.Experimental.GraphView;
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
                Model.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEntryButtonIconSprite
                );

                Node.titleContainer.Add(Model.ContentButton);
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
                    mainContainer.AddToClassList(StyleConfig.OptionRootNode_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.OptionRootNode_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.OptionRootNodeInnerContainer);
                }

                void SetupOptionRootIconImage()
                {
                    rootIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.SpriteConfig.OptionRootIconSprite,
                        imageUSS01: StyleConfig.OptionRootNode_Icon_Image
                    );
                }

                void SetupOptionRootTitleLabel()
                {
                    rootTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                        labelUSS01: StyleConfig.OptionRootNode_Title_Label
                    );
                }

                void SetupOptionRootTitleTextField()
                {
                    Model.RootTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElement
                        (
                            isMultiLine: false,
                            placeholderText: Model.RootTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.OptionRootNode_Title_TextField
                        );
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
            Node.SetPosition
            (
                details,
                leftSideAlignmentReferencePort: Model.OutputOptionPort,
                rightSideAlignmentReferencePort: Model.InputDefaultPort,
                middleAlignmentReferencePort: Model.InputDefaultPort
            );
        }
    }
}