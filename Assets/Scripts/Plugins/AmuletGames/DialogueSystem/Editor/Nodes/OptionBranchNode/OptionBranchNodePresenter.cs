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
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionModifierButtonIconSprite
                );

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
                    mainContainer.AddToClassList(StyleConfig.OptionBranchNode_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.OptionBranchNode_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.OptionBranchNode_InnerContainer);
                }

                void SetupBranchIconImage()
                {
                    branchIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.SpriteConfig.OptionBranchIconSprite,
                        imageUSS01: StyleConfig.OptionBranchNode_Icon_Image
                    );
                }

                void SetupBranchTitleLabel()
                {
                    branchTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionBranchNode_BranchTitleLabel_LabelText,
                        labelUSS01: StyleConfig.OptionBranchNode_Title_Label
                    );
                }

                void SetupBranchTitleTextField()
                {
                    Model.BranchTitleTextFieldModel.TextField =
                        LanguageTextFieldPresenter.CreateElement
                        (
                            isMultiLine: false,
                            placeholderText: Model.BranchTitleTextFieldModel.PlaceholderText,
                            fieldUSS01: StyleConfig.OptionBranchNode_Title_TextField
                        );
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
            Node.SetPosition
            (
                details,
                leftSideAlignmentReferencePort: Model.OutputDefaultPort,
                rightSideAlignmentReferencePort: Model.InputOptionPort,
                middleAlignmentReferencePort: Model.InputOptionPort
            );
        }
    }
}