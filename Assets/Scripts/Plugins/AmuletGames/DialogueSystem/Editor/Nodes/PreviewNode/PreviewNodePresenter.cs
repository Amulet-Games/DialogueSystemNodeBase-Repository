using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

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
            View.InputDefaultPort = DefaultPortPresenter.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            View.OutputDefaultPort = DefaultPortPresenter.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.OutputDefaultPort);
            Node.RefreshPorts();
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
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_L
                );
            }

            void SetupRightPortraitImage()
            {
                View.RightPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_R
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