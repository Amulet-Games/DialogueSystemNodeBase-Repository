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
        /// Constructor of the preview node presenter module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public PreviewNodePresenter(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            base.CreateContentElements();

            SetupElements();

            void SetupElements()
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
                    previewImageBox.AddToClassList(StyleConfig.Instance.PreviewNode_PreviewImage_Box);

                    previewSpriteBox = new();
                    previewSpriteBox.AddToClassList(StyleConfig.Instance.PreviewNode_PreviewSprite_Box);

                    middleEmptyBox = new();
                    middleEmptyBox.AddToClassList(StyleConfig.Instance.PreviewNode_MiddleEmpty_Box);
                }

                void SetupLeftPortraitImage()
                {
                    Model.LeftPortraitImage = CommonImagePresenter.CreateElements
                    (
                        imageUSS01: StyleConfig.Instance.PreviewNode_PreviewImage_Image,
                        imageUSS02: StyleConfig.Instance.PreviewNode_PreviewImage_Image_L
                    );
                }

                void SetupRightPortraitImage()
                {
                    Model.RightPortraitImage = CommonImagePresenter.CreateElements
                    (
                        imageUSS01: StyleConfig.Instance.PreviewNode_PreviewImage_Image,
                        imageUSS02: StyleConfig.Instance.PreviewNode_PreviewImage_Image_R
                    );
                }

                void SetupLeftPortraitObjectField()
                {
                    Model.LeftPortraitObjectFieldModel.ObjectField =
                        CommonObjectFieldPresenter.CreateElements<Sprite>
                        (
                            fieldUSS01: StyleConfig.Instance.PreviewNode_PreviewSprite_ObjectField,
                            fieldUSS02: StyleConfig.Instance.PreviewNode_PreviewSprite_ObjectField_L
                        );

                    new CommonObjectFieldCallback<Sprite>(
                        model: Model.LeftPortraitObjectFieldModel,
                        additionalChangeEvent: LeftPortraitObjectFieldChangeEvent).RegisterEvents();
                }

                void SetupRightPortraitObjectField()
                {
                    Model.RightPortraitObjectFieldModel.ObjectField =
                        CommonObjectFieldPresenter.CreateElements<Sprite>
                        (
                            fieldUSS01: StyleConfig.Instance.PreviewNode_PreviewSprite_ObjectField,
                            fieldUSS02: StyleConfig.Instance.PreviewNode_PreviewSprite_ObjectField_R
                        );

                    new CommonObjectFieldCallback<Sprite>(
                        model: Model.RightPortraitObjectFieldModel,
                        additionalChangeEvent: RightPortraitObjectFieldChangeEvent).RegisterEvents();
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
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Input_LabelText
            );

            Model.OutputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Output_LabelText
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The action to invoke when the left portrait object field value is changed.
        /// </summary>
        void LeftPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            Model.LeftPortraitImage.image = Model.LeftPortraitObjectFieldModel.Value.texture;
        }


        /// <summary>
        /// The action to invoke when the right portrait object field value is changed.
        /// </summary>
        void RightPortraitObjectFieldChangeEvent(ChangeEvent<Sprite> evt)
        {
            Model.RightPortraitImage.image = Model.RightPortraitObjectFieldModel.Value.texture;
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var defaultOutput = Model.OutputDefaultPort;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(Node.GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectOutputPort_LabelText,
                action: action => defaultOutput.Disconnect(Node.GraphViewer),
                status: defaultOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            var isAnyConnected = defaultInput.connected
                              || defaultOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(Node.GraphViewer);

                    defaultOutput.Disconnect(Node.GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void PostProcessPositionDetails(NodeCreationDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            void AlignConnectorPosition()
            {
                Vector2 result = Node.localBound.position;

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

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StyleConfig.Instance.Global_Visible_Hidden);
            }
        }
    }
}