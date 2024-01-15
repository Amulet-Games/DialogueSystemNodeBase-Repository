using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

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
            // Input
            {
                View.InputOptionPortCell = OptionPortCellPresenter.CreateElement
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.OptionEdgeConnectorSearchWindowView,
                    direction: Direction.Input,
                    isIndexDominant: false
                );

                Node.Add(View.InputOptionPortCell);
            }

            // Output
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Output_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.OutputPort = PortManager.Instance.Create(portModel);
                View.OutputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.OutputPort);
            }
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;
            VisualElement branchTitleMainContainer;
            VisualElement branchTitleOuterContainer;
            VisualElement branchTitleInnerContainer;

            Image branchTitleImage;
            Label branchTitleLabel;

            CreateContentButton();

            CreateContainers();

            CreateBranchTitleImage();

            CreateBranchTitleLabel();

            CreateBranchTitleField();

            AddElementsToContainer();

            AddContainersToNode();

            void CreateContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddCondition_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddConditionButtonIconSprite
                );
            }

            void CreateContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                branchTitleMainContainer = new();
                branchTitleMainContainer.AddToClassList(StyleConfig.OptionBranchNode_BranchTitle_Main_Container);

                branchTitleOuterContainer = new();
                branchTitleOuterContainer.AddToClassList(StyleConfig.OptionBranchNode_BranchTitle_Outer_Container);

                branchTitleInnerContainer = new();
                branchTitleInnerContainer.AddToClassList(StyleConfig.OptionBranchNode_BranchTitle_Inner_Container);
            }

            void CreateBranchTitleImage()
            {
                branchTitleImage = CommonImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.BranchTitleFieldSprite,
                    USS01: StyleConfig.OptionBranchNode_BranchTitle_Image
                );
            }

            void CreateBranchTitleLabel()
            {
                branchTitleLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.OptionBranchNode_BranchTitleLabel_LabelText,
                    USS: StyleConfig.OptionBranchNode_BranchTitle_Label
                );
            }

            void CreateBranchTitleField()
            {
                LanguageTextFieldPresenter.CreateElement
                (
                    view: View.BranchTitleFieldView,
                    multiline: false,
                    fieldUSS: StyleConfig.OptionBranchNode_BranchTitle_Field
                );
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

                branchTitleOuterContainer.Add(branchTitleImage);
                branchTitleOuterContainer.Add(branchTitleInnerContainer);

                branchTitleInnerContainer.Add(branchTitleLabel);
                branchTitleInnerContainer.Add(View.BranchTitleFieldView.Field);

                branchTitleMainContainer.Add(branchTitleOuterContainer);
                contentContainer.Add(branchTitleMainContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}