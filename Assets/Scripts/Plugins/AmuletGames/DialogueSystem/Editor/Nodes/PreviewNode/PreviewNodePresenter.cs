using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodePresenter : NodePresenterFrameBase
    <
        PreviewNode,
        PreviewNodeView,
        PreviewNodeCallback
    >
    {
        /// <inheritdoc />
        public override PreviewNode CreateElements
        (
            PreviewNodeView view,
            PreviewNodeCallback callback,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new PreviewNode(view, callback, graphViewer);

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
        void CreatePortElements(PreviewNode node, PreviewNodeView view)
        {
            view.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            view.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(view.InputDefaultPort);
            node.Add(view.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreateContentElements(PreviewNode node, PreviewNodeView view)
        {
            Box previewImageBox;
            Box previewSpriteBox;
            Box middleEmptyBox;

            SetupContainers();

            SetupLeftPortraitImage();

            SetupRightPortraitImage();

            SetupLeftPortraitObjectField();

            SetupRightPortraitObjectField();

            AddElementsToContainer();

            AddContainerToNode();

            void SetupContainers()
            {
                previewImageBox = new();
                previewImageBox.AddToClassList(StyleConfig.PreviewNode_PreviewImage_Box);

                previewSpriteBox = new();
                previewSpriteBox.AddToClassList(StyleConfig.PreviewNode_PreviewSprite_Box);

                middleEmptyBox = new();
                middleEmptyBox.AddToClassList(StyleConfig.PreviewNode_MiddleEmpty_Box);
            }

            void SetupLeftPortraitImage()
            {
                view.LeftPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_L
                );
            }

            void SetupRightPortraitImage()
            {
                view.RightPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_R
                );
            }

            void SetupLeftPortraitObjectField()
            {   
                CommonObjectFieldPresenter.CreateElement<Sprite>
                (
                    view: view.LeftPortraitObjectFieldView,
                    fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                    fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_L
                );
            }

            void SetupRightPortraitObjectField()
            {
                CommonObjectFieldPresenter.CreateElement<Sprite>
                (
                    view: view.RightPortraitObjectFieldView,
                    fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                    fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_R
                );
            }

            void AddElementsToContainer()
            {
                previewImageBox.Add(view.LeftPortraitImage);
                previewImageBox.Add(view.RightPortraitImage);

                previewSpriteBox.Add(view.LeftPortraitObjectFieldView.Field);
                previewSpriteBox.Add(middleEmptyBox);
                previewSpriteBox.Add(view.RightPortraitObjectFieldView.Field);
            }

            void AddContainerToNode()
            {
                node.ContentContainer.Add(previewImageBox);
                node.ContentContainer.Add(previewSpriteBox);
            }
        }
    }
}