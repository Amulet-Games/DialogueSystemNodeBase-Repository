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
            View.InputDefaultPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                name: StringConfig.DefaultPort_Input_LabelText
            );

            View.OutputOptionPort = PortManager.Instance.CreateOption
            (
                connectorWindow: Node.GraphViewer.NodeCreateOptionConnectorWindow,
                direction: Direction.Output,
                isGroup: false
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.OutputOptionPort);
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
                rootMainContainer.AddToClassList(StyleConfig.OptionRoot_Main_Container);

                rootOuterContainer = new();
                rootOuterContainer.AddToClassList(StyleConfig.OptionRoot_Outer_Container);

                rootInnerContainer = new();
                rootInnerContainer.AddToClassList(StyleConfig.OptionRoot_Inner_Container);
            }

            void SetupOptionRootIconImage()
            {
                rootIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.OptionRootIconSprite,
                    imageUSS01: StyleConfig.OptionRoot_RootIcon_Image
                );
            }

            void SetupOptionRootTitleLabel()
            {
                rootTitleLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                    labelUSS: StyleConfig.OptionRoot_RootTitle_Label
                );
            }

            void SetupOptionRootTitleTextField()
            {
                View.RootTitleTextFieldView.Field = LanguageTextFieldPresenter.CreateElement
                (
                    multiline: false,
                    placeholderText: View.RootTitleTextFieldView.placeholderText,
                    fieldUSS: StyleConfig.OptionRoot_RootTitleText_Field
                );
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

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