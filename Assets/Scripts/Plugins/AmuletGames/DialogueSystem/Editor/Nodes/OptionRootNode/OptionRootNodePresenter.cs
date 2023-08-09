using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodePresenter : NodePresenterFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeObserver
    >
    {
        /// <inheritdoc />
        public override OptionRootNode CreateElements
        (
            OptionRootNodeView view,
            OptionRootNodeObserver observer,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new OptionRootNode(view, observer, graphViewer, headBar);

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
        void CreatePortElements(OptionRootNode node, OptionRootNodeView view)
        {
            view.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            view.OutputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output
            );

            node.Add(view.InputDefaultPort);
            node.Add(view.OutputOptionPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreateContentElements(OptionRootNode node, OptionRootNodeView view)
        {
            SetupContentButton();

            SetupOptionRoot();

            void SetupContentButton()
            {
                view.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEntryButtonIconSprite
                );

                node.titleContainer.Add(view.ContentButton);
            }

            void SetupOptionRoot()
            {
                VisualElement mainContainer;
                VisualElement outerContainer;
                VisualElement InnerContainer;

                Image rootIconImage;
                Label rootTitleLabel;

                SetupContainers();

                SetupOptionRootIconImage();

                SetupOptionRootTitleLabel();

                SetupOptionRootTitleTextField();

                AddElementsToContainer();

                AddContainersToNode();

                void SetupContainers()
                {
                    mainContainer = new();
                    mainContainer.AddToClassList(StyleConfig.OptionRoot_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.OptionRoot_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.OptionRoot_InnerContainer);
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
                    view.RootTitleTextFieldView.TextField = LanguageTextFieldPresenter.CreateElement
                    (
                        isMultiLine: false,
                        placeholderText: view.RootTitleTextFieldView.PlaceholderText,
                        fieldUSS: StyleConfig.OptionRoot_Title_TextField
                    );
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(rootIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(rootTitleLabel);
                    InnerContainer.Add(view.RootTitleTextFieldView.TextField);
                }

                void AddContainersToNode()
                {
                    node.ContentContainer.Add(mainContainer);
                }
            }
        }
    }
}