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
        public override void CreateElements(OptionBranchNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();

            CreateContentElements();
        }


        /// <summary>
        /// Create the node's port elements.
        /// </summary>
        void CreatePortElements()
        {
            View.InputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input
            );

            View.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.InputOptionPort);
            Node.Add(View.OutputDefaultPort);
            Node.RefreshPorts();
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;
            VisualElement branchMainContainer;
            VisualElement branchOuterContainer;
            VisualElement branchInnerContainer;

            Image branchIconImage;
            Label branchTitleLabel;

            SetupContentButton();

            SetupContainers();

            SetupBranchIconImage();

            SetupBranchTitleLabel();

            SetupBranchTitleTextField();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionModifierButtonIconSprite
                );
            }

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                branchMainContainer = new();
                branchMainContainer.AddToClassList(StyleConfig.OptionBranch_MainContainer);

                branchOuterContainer = new();
                branchOuterContainer.AddToClassList(StyleConfig.OptionBranch_OuterContainer);

                branchInnerContainer = new();
                branchInnerContainer.AddToClassList(StyleConfig.OptionBranch_InnerContainer);
            }

            void SetupBranchIconImage()
            {
                branchIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.OptionBranchIconSprite,
                    imageUSS01: StyleConfig.OptionBranch_Icon
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
                View.BranchTitleTextFieldView.Field = LanguageTextFieldPresenter.CreateElement
                (
                    isMultiLine: false,
                    placeholderText: View.BranchTitleTextFieldView.placeholderText,
                    fieldUSS: StyleConfig.OptionBranch_Title_TextField
                );
            }

            void AddElementsToContainer()
            {
                Node.titleContainer.Add(View.ContentButton);

                branchOuterContainer.Add(branchIconImage);
                branchOuterContainer.Add(branchInnerContainer);

                branchInnerContainer.Add(branchTitleLabel);
                branchInnerContainer.Add(View.BranchTitleTextFieldView.Field);

                branchMainContainer.Add(branchOuterContainer);
                contentContainer.Add(branchMainContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}