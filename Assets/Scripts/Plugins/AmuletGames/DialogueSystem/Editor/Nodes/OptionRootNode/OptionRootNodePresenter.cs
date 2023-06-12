using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodePresenter : NodePresenterFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel
    >
    {
        /// <inheritdoc />
        public override OptionRootNode CreateElements(OptionRootNodeModel model, GraphViewer graphViewer)
        {
            var node = new OptionRootNode(model, graphViewer);

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
        void CreatePortElements(OptionRootNode node, OptionRootNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            model.OutputOptionPort = OptionPort.CreateElement<OptionEdge>
            (
                connectorWindow: node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output
            );

            node.Add(model.InputDefaultPort);
            node.Add(model.OutputOptionPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(OptionRootNode node, OptionRootNodeModel model)
        {
            SetupContentButton();

            SetupOptionRootGroup();

            void SetupContentButton()
            {
                model.ContentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ContentButton_AddEntry_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.AddEntryButtonIconSprite
                );

                node.titleContainer.Add(model.ContentButton);
            }

            void SetupOptionRootGroup()
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
                    mainContainer.AddToClassList(StyleConfig.OptionRootNode_MainContainer);

                    outerContainer = new();
                    outerContainer.AddToClassList(StyleConfig.OptionRootNode_OuterContainer);

                    InnerContainer = new();
                    InnerContainer.AddToClassList(StyleConfig.OptionRootNodeInnerContainer);
                }

                void SetupOptionRootIconImage()
                {
                    rootIconImage = CommonImagePresenter.CreateElement
                    (
                        imageSprite: ConfigResourcesManager.SpriteConfig.OptionRootIconSprite,
                        imageUSS01: StyleConfig.OptionRootNode_Icon_Image
                    );
                }

                void SetupOptionRootTitleLabel()
                {
                    rootTitleLabel = CommonLabelPresenter.CreateElement
                    (
                        labelText: StringConfig.OptionRootNode_RootTitleLabel_LabelText,
                        labelUSS01: StyleConfig.OptionRootNode_Title_Label
                    );
                }

                void SetupOptionRootTitleTextField()
                {
                    model.RootTitleTextFieldModel.TextField = LanguageTextFieldPresenter.CreateElement
                    (
                        isMultiLine: false,
                        placeholderText: model.RootTitleTextFieldModel.PlaceholderText,
                        fieldUSS01: StyleConfig.OptionRootNode_Title_TextField
                    );
                }

                void AddElementsToContainer()
                {
                    mainContainer.Add(outerContainer);

                    outerContainer.Add(rootIconImage);
                    outerContainer.Add(InnerContainer);

                    InnerContainer.Add(rootTitleLabel);
                    InnerContainer.Add(model.RootTitleTextFieldModel.TextField);
                }

                void AddContainersToNode()
                {
                    node.ContentContainer.Add(mainContainer);
                }
            }
        }
    }
}