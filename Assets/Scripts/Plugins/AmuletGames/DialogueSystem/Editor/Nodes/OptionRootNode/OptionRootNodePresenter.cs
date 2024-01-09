using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

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
            // Input
            {
                var portModel = new PortModel
                (
                    port: PortModel.Port.Default,
                    Direction.Input,
                    capacity: Capacity.Multi,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.InputPort = PortManager.Instance.Create(portModel);
                View.InputPort.AddEdgeConnector
                (
                    nodeCreateConnectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                    nodeCreateWindowEntries: NodeCreateEntryProvider.DefaultNodeInputEntries,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.InputPort);
            }

            // Output
            {
                View.OutputOptionPortGroup = OptionPortGroupPresenter.CreateElement
                (
                    direction: Direction.Output,
                    graphViewer: Node.GraphViewer
                );

                Node.OutputContainer.Add(View.OutputOptionPortGroup);
            }
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

            CreateContentButton();

            CreateContainers();

            CreateRootTitleImage();

            CreateRootTitleLabel();

            CreateRootTitleField();

            AddElementsToContainer();

            AddContainersToNode();

            void CreateContentButton()
            {
                View.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEntryButtonIconSprite
                );
            }

            void CreateContainers()
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

            void CreateRootTitleImage()
            {
                rootTitleImage = CommonImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RootTitleFieldSprite,
                    USS01: StyleConfig.OptionRootNode_RootTitle_Image
                );
            }

            void CreateRootTitleLabel()
            {
                rootTitleLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                    USS: StyleConfig.OptionRootNode_RootTitle_Label
                );
            }

            void CreateRootTitleField()
            {
                LanguageTextFieldPresenter.CreateElement
                (
                    view: View.RootTitleFieldView,
                    multiline: false,
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