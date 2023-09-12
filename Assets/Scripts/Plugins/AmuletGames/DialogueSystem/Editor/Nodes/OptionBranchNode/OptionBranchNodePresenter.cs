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
            View.InputOptionPort = PortManager.Instance.CreateOption
            (
                connectorWindow: Node.GraphViewer.NodeCreateOptionConnectorWindow,
                direction: Direction.Input,
                isGroup: false
            );

            View.OutputDefaultPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                name: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.InputOptionPort);
            Node.Add(View.OutputDefaultPort);
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
                branchMainContainer.AddToClassList(StyleConfig.OptionBranch_Main_Container);

                branchOuterContainer = new();
                branchOuterContainer.AddToClassList(StyleConfig.OptionBranch_Outer_Container);

                branchInnerContainer = new();
                branchInnerContainer.AddToClassList(StyleConfig.OptionBranch_Inner_Container);
            }

            void SetupBranchIconImage()
            {
                branchIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.OptionBranchIconSprite,
                    imageUSS01: StyleConfig.OptionBranch_BranchIcon_Image
                );
            }

            void SetupBranchTitleLabel()
            {
                branchTitleLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.OptionBranchNode_BranchTitleLabel_LabelText,
                    labelUSS: StyleConfig.OptionBranch_BranchTitle_Label
                );
            }

            void SetupBranchTitleTextField()
            {
                View.BranchTitleTextFieldView.Field = LanguageTextFieldPresenter.CreateElement
                (
                    multiline: false,
                    placeholderText: View.BranchTitleTextFieldView.placeholderText,
                    fieldUSS: StyleConfig.OptionBranch_BranchTitleText_Field
                );
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

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