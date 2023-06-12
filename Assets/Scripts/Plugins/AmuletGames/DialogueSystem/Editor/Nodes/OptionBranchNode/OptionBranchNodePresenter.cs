using UnityEditor.Experimental.GraphView;
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
        /// <inheritdoc />
        public override OptionBranchNode CreateElements(OptionBranchNodeModel model, GraphViewer graphViewer)
        {
            var node = new OptionBranchNode(model, graphViewer);

            CreateTitleElements(node, model);
            CreatePortElements(node, model);
            CreateContentElements(node, model);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreatePortElements(OptionBranchNode node, OptionBranchNodeModel model)
        {
            model.InputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input
            );

            model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(model.InputOptionPort);
            node.Add(model.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(OptionBranchNode node, OptionBranchNodeModel model)
        {
            SetupContentButton();

            SetupOptionBranchGroup();

            void SetupContentButton()
            {
                model.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionModifierButtonIconSprite
                );

                node.titleContainer.Add(model.ContentButton);
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
                    model.BranchTitleTextFieldModel.TextField = LanguageTextFieldPresenter.CreateElement
                    (
                        isMultiLine: false,
                        placeholderText: model.BranchTitleTextFieldModel.PlaceholderText,
                        fieldUSS01: StyleConfig.OptionBranchNode_Title_TextField
                    );
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(branchIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(branchTitleLabel);
                    InnerContainer.Add(model.BranchTitleTextFieldModel.TextField);
                }

                void AddContainersToNode()
                {
                    node.ContentContainer.Add(mainContainer);
                }
            }
        }
    }
}