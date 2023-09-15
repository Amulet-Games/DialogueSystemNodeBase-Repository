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
            VisualElement rootTitleMainContainer;
            VisualElement rootTitleOuterContainer;
            VisualElement rootTitleInnerContainer;

            Image rootTitleImage;
            Label rootTitleLabel;

            SetupContentButton();

            SetupContainers();

            SetupRootTitleImage();

            SetupRootTitleLabel();

            SetupRootTitleField();

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

                rootTitleMainContainer = new();
                rootTitleMainContainer.AddToClassList(StyleConfig.OptionRootNode_RootTitle_Main_Container);

                rootTitleOuterContainer = new();
                rootTitleOuterContainer.AddToClassList(StyleConfig.OptionRootNode_RootTitle_Outer_Container);

                rootTitleInnerContainer = new();
                rootTitleInnerContainer.AddToClassList(StyleConfig.OptionRootNode_RootTitle_Inner_Container);
            }

            void SetupRootTitleImage()
            {
                rootTitleImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.RootTitleFieldSprite,
                    imageUSS01: StyleConfig.OptionRootNode_RootTitle_Image
                );
            }

            void SetupRootTitleLabel()
            {
                rootTitleLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                    labelUSS: StyleConfig.OptionRootNode_RootTitle_Label
                );
            }

            void SetupRootTitleField()
            {
                View.RootTitleFieldView.Field = LanguageTextFieldPresenter.CreateElement
                (
                    multiline: false,
                    placeholderText: View.RootTitleFieldView.placeholderText,
                    fieldUSS: StyleConfig.OptionRootNode_RootTitle_Field
                );
            }

            void AddElementsToContainer()
            {
                Node.topContainer.Add(View.ContentButton);

                rootTitleOuterContainer.Add(rootTitleImage);
                rootTitleOuterContainer.Add(rootTitleInnerContainer);

                rootTitleInnerContainer.Add(rootTitleLabel);
                rootTitleInnerContainer.Add(View.RootTitleFieldView.Field);

                rootTitleMainContainer.Add(rootTitleOuterContainer);
                contentContainer.Add(rootTitleMainContainer);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}