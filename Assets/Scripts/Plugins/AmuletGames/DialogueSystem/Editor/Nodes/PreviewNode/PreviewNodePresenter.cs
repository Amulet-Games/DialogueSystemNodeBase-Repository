using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodePresenter : NodePresenterFrameBase
    <
        PreviewNode,
        PreviewNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(PreviewNode node)
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
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.InputPort = PortManager.Instance.Create(portModel);
                View.InputPort.AddEdgeConnector
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.InputPort);
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

            Box previewImageBox;
            Box previewSpriteBox;
            Box middleEmptyBox;

            SetupContainers();

            SetupLeftPortraitImage();

            SetupRightPortraitImage();

            SetupLeftPortraitObjectField();

            SetupRightPortraitObjectField();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);

                previewImageBox = new();
                previewImageBox.AddToClassList(StyleConfig.PreviewNode_PreviewImage_Box);

                previewSpriteBox = new();
                previewSpriteBox.AddToClassList(StyleConfig.PreviewNode_PreviewSprite_Box);

                middleEmptyBox = new();
                middleEmptyBox.AddToClassList(StyleConfig.PreviewNode_MiddleEmpty_Box);
            }

            void SetupLeftPortraitImage()
            {
                View.LeftPortraitImage = CommonImagePresenter.CreateElement
                (
                    USS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    USS02: StyleConfig.PreviewNode_PreviewImage_Image_L
                );
            }

            void SetupRightPortraitImage()
            {
                View.RightPortraitImage = CommonImagePresenter.CreateElement
                (
                    USS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    USS02: StyleConfig.PreviewNode_PreviewImage_Image_R
                );
            }

            void SetupLeftPortraitObjectField()
            {   
                CommonObjectFieldPresenter.CreateElement
                (
                    view: View.LeftPortraitObjectFieldView,
                    fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                    fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_L
                );
            }

            void SetupRightPortraitObjectField()
            {
                CommonObjectFieldPresenter.CreateElement
                (
                    view: View.RightPortraitObjectFieldView,
                    fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                    fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_R
                );
            }

            void AddElementsToContainer()
            {
                previewImageBox.Add(View.LeftPortraitImage);
                previewImageBox.Add(View.RightPortraitImage);

                previewSpriteBox.Add(View.LeftPortraitObjectFieldView.Field);
                previewSpriteBox.Add(middleEmptyBox);
                previewSpriteBox.Add(View.RightPortraitObjectFieldView.Field);

                contentContainer.Add(previewImageBox);
                contentContainer.Add(previewSpriteBox);
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}