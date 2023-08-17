using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodePresenter : NodePresenterFrameBase
    <
        OptionRootNode,
        OptionRootNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(OptionRootNode node)
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
            View.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            View.OutputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.OutputOptionPort);
            Node.RefreshPorts();
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;
            VisualElement rootMainContainer;
            VisualElement rootOuterContainer;
            VisualElement rootInnerContainer;

            Image rootIconImage;
            Label rootTitleLabel;

            SetupContentButton();

            SetupContainers();

            SetupOptionRootIconImage();

            SetupOptionRootTitleLabel();

            SetupOptionRootTitleTextField();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEntryButtonIconSprite
                );
            }

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                rootMainContainer = new();
                rootMainContainer.AddToClassList(StyleConfig.OptionRoot_MainContainer);

                rootOuterContainer = new();
                rootOuterContainer.AddToClassList(StyleConfig.OptionRoot_OuterContainer);

                rootInnerContainer = new();
                rootInnerContainer.AddToClassList(StyleConfig.OptionRoot_InnerContainer);
            }

            void SetupOptionRootIconImage()
            {
                rootIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.OptionRootIconSprite,
                    imageUSS01: StyleConfig.OptionRoot_Icon
                );
            }

            void SetupOptionRootTitleLabel()
            {
                rootTitleLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                    labelUSS: StyleConfig.OptionRoot_Title_Label
                );
            }

            void SetupOptionRootTitleTextField()
            {
                View.RootTitleTextFieldView.Field = LanguageTextFieldPresenter.CreateElement
                (
                    isMultiLine: false,
                    placeholderText: View.RootTitleTextFieldView.placeholderText,
                    fieldUSS: StyleConfig.OptionRoot_Title_TextField
                );
            }

            void AddElementsToContainer()
            {
                Node.titleContainer.Add(View.ContentButton);

                rootOuterContainer.Add(rootIconImage);
                rootOuterContainer.Add(rootInnerContainer);

                rootInnerContainer.Add(rootTitleLabel);
                rootInnerContainer.Add(View.RootTitleTextFieldView.Field);

                rootMainContainer.Add(rootOuterContainer);
                contentContainer.Add(rootMainContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}