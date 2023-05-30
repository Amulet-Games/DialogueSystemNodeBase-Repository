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
        // ----------------------------- Constructor -----------------------------

        /// <summary>
        /// Constructor of the preview node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public PreviewNodePresenter(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
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
                Model.LeftPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_L
                );
            }

            void SetupRightPortraitImage()
            {
                Model.RightPortraitImage = CommonImagePresenter.CreateElement
                (
                    imageUSS01: StyleConfig.PreviewNode_PreviewImage_Image,
                    imageUSS02: StyleConfig.PreviewNode_PreviewImage_Image_R
                );
            }

            void SetupLeftPortraitObjectField()
            {
                Model.LeftPortraitObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<Sprite>
                    (
                        fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                        fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_L
                    );
            }

            void SetupRightPortraitObjectField()
            {
                Model.RightPortraitObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<Sprite>
                    (
                        fieldUSS01: StyleConfig.PreviewNode_PreviewSprite_ObjectField,
                        fieldUSS02: StyleConfig.PreviewNode_PreviewSprite_ObjectField_R
                    );
            }

            void AddElementsToContainer()
            {
                previewImageBox.Add(Model.LeftPortraitImage);
                previewImageBox.Add(Model.RightPortraitImage);

                previewSpriteBox.Add(Model.LeftPortraitObjectFieldModel.ObjectField);
                previewSpriteBox.Add(middleEmptyBox);
                previewSpriteBox.Add(Model.RightPortraitObjectFieldModel.ObjectField);
            }

            void AddContainerToNode()
            {
                Node.ContentContainer.Add(previewImageBox);
                Node.ContentContainer.Add(previewSpriteBox);
            }
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            Model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                Vector2 result = details.CreatePosition;

                switch (details.HorizontalAlignmentType)
                {
                    case HorizontalAlignmentType.LEFT:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.OutputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width;

                        break;
                    case HorizontalAlignmentType.MIDDLE:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        result.x -= Node.localBound.width / 2;

                        break;
                    case HorizontalAlignmentType.RIGHT:

                        result.y -= (Node.titleContainer.worldBound.height
                                  + Model.InputDefaultPort.localBound.position.y
                                  + NodeConfig.ManualCreateYOffset)
                                  / Node.GraphViewer.scale;

                        break;
                }

                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                var port = (DefaultPort)details.ConnectorPort;
                var isInput = port.IsInput();

                if (port.connected)
                {
                    port.Disconnect(Node.GraphViewer);
                }

                var edge = EdgeManager.Instance.Connect
                (
                    output: !isInput ? port : Model.OutputDefaultPort,
                    input: isInput ? port : Model.InputDefaultPort
                );

                Node.GraphViewer.Add(edge);
            }
        }
    }
}