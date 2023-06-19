using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodePresenter : NodePresenterFrameBase
    <
        PreviewNode,
        PreviewNodeModel
    >
    {
        /// <inheritdoc />
        public override PreviewNode CreateElements(PreviewNodeModel model, GraphViewer graphViewer)
        {
            var node = new PreviewNode(model, graphViewer);

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
        void CreatePortElements(PreviewNode node, PreviewNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(model.InputDefaultPort);
            node.Add(model.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(PreviewNode node, PreviewNodeModel model)
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
                model.LeftPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_L
                );
            }

            void SetupRightPortraitImage()
            {
                model.RightPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_R
                );
            }

            void SetupLeftPortraitObjectField()
            {
                model.LeftPortraitObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<Sprite>
                    (
                        fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                        fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_L
                    );
            }

            void SetupRightPortraitObjectField()
            {
                model.RightPortraitObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<Sprite>
                    (
                        fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                        fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_R
                    );
            }

            void AddElementsToContainer()
            {
                previewImageBox.Add(model.LeftPortraitImage);
                previewImageBox.Add(model.RightPortraitImage);

                previewSpriteBox.Add(model.LeftPortraitObjectFieldModel.ObjectField);
                previewSpriteBox.Add(middleEmptyBox);
                previewSpriteBox.Add(model.RightPortraitObjectFieldModel.ObjectField);
            }

            void AddContainerToNode()
            {
                node.ContentContainer.Add(previewImageBox);
                node.ContentContainer.Add(previewSpriteBox);
            }
        }
    }
}