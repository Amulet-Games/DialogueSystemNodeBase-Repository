using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodePresenter : NodePresenterFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView
    >
    {
        /// <inheritdoc />
        public override OptionBranchNode CreateElements
        (
            OptionBranchNodeView view,
            GraphViewer graphViewer,
            HeadBar headBar = null
        )
        {
            var node = new OptionBranchNode(view, graphViewer, headBar);

            CreateTitleElements(node, view);
            CreatePortElements(node, view);
            CreateContentElements(node, view);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreatePortElements(OptionBranchNode node, OptionBranchNodeView view)
        {
            view.InputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input
            );

            view.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(view.InputOptionPort);
            node.Add(view.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreateContentElements(OptionBranchNode node, OptionBranchNodeView view)
        {
            SetupContentButton();

            SetupOptionBranch();

            void SetupContentButton()
            {
                view.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionModifierButtonIconSprite
                );

                node.titleContainer.Add(view.ContentButton);
            }

            void SetupOptionBranch()
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
                    mainContainer.AddToClassList(StyleConfig.OptionBranch_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.OptionBranch_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.OptionBranch_InnerContainer);
                }

                void SetupBranchIconImage()
                {
                    branchIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.SpriteConfig.OptionBranchIconSprite,
                        imageUSS01: StyleConfig.OptionBranch_Icon_Image
                    );
                }

                void SetupBranchTitleLabel()
                {
                    branchTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionBranchNode_BranchTitleLabel_LabelText,
                        labelUSS: StyleConfig.OptionBranch_Title_Label
                    );
                }

                void SetupBranchTitleTextField()
                {
                    view.BranchTitleTextFieldView.TextField = LanguageTextFieldPresenter.CreateElement
                    (
                        isMultiLine: false,
                        placeholderText: view.BranchTitleTextFieldView.PlaceholderText,
                        fieldUSS: StyleConfig.OptionBranch_Title_TextField
                    );
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(branchIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(branchTitleLabel);
                    InnerContainer.Add(view.BranchTitleTextFieldView.TextField);
                }

                void AddContainersToNode()
                {
                    node.ContentContainer.Add(mainContainer);
                }
            }
        }
    }
}