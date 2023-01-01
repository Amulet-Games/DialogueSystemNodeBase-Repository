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
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public PreviewNodePresenter(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddPortraitImages();

            AddSpriteObjectFields();

            void AddPortraitImages()
            {
                // New box container.
                Box portraitImageElementsBox = new();
                portraitImageElementsBox.AddToClassList(StylesConfig.PreviewNode_Image_Box);

                // New images.
                Model.LeftPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_L
                );

                Model.RightPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_R
                );

                // Add to box
                portraitImageElementsBox.Add(Model.LeftPortraitImage);
                portraitImageElementsBox.Add(Model.RightPortraitImage);

                // Add to node
                Node.mainContainer.Add(portraitImageElementsBox);
            }

            void AddSpriteObjectFields()
            {
                // New box container.
                Box imageObjectFieldsBox = new();
                imageObjectFieldsBox.AddToClassList(StylesConfig.PreviewNode_ObjectField_Box);

                // New object fields.
                var leftSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: Model.LeftSpriteContainer,
                    containerValueChangedAction: LeftSpriteObjectContainerValueChangedAction,
                    fieldIcon: AssetsConfig.ImageFieldIconSprite,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_L
                );

                var rightSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: Model.RightSpriteContainer,
                    containerValueChangedAction: RightSpriteObjectContainerValueChangedAction,
                    fieldIcon: AssetsConfig.ImageFieldIconSprite,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_R
                );

                // Add to box
                imageObjectFieldsBox.Add(leftSpriteField);
                imageObjectFieldsBox.Add(rightSpriteField);

                // Add to node
                Node.mainContainer.Add(imageObjectFieldsBox);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeInputLabelText,
                isSiblings: false
            );

            // Output port.
            Model.OutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeOutputLabelText,
                isSiblings: false
            );

            // Refresh ports.
            Node.RefreshPorts();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the left sprite object container value is changed.
        /// </summary>
        void LeftSpriteObjectContainerValueChangedAction()
            => ImageElementHelper.UpdateImagePreview
                (sprite: Model.LeftSpriteContainer.Value, image: Model.LeftPortraitImage);


        /// <summary>
        /// Action that invoked when the right sprite object container value is changed.
        /// </summary>
        void RightSpriteObjectContainerValueChangedAction()
                => ImageElementHelper.UpdateImagePreview
                    (sprite: Model.RightSpriteContainer.Value, image: Model.RightPortraitImage);


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectInputPortAction();

            AppendDisconnectOuputPortAction();

            AppendDisconnectAllPortsAction();

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectOuputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                var isInputPortConnected = Model.InputPort.connected;
                var isOutputPortConnected = Model.OutputPort.connected;

                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isOutputPortConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    Model.InputPort.DisconnectPort();
                    // Disconnect Ouput port.
                    Model.OutputPort.DisconnectPort();
                }
            }
        }


        // ----------------------------- Post Process Position Details Services -----------------------------
        /// <inheritdoc />
        protected override void PostProcessPositionDetails(NodeCreationDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (details.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Left:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width;

                        break;
                    case C_Alignment_HorizontalType.Middle:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;

                        break;
                    case C_Alignment_HorizontalType.Right:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;
                        break;
                }

                // Apply the final position result to the node.
                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connnector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                // Create local reference for the connector port.
                Port connectorPort = details.ConnectorPort;

                // If the connector port is connecting to another port, disconnect them first.
                if (connectorPort.connected)
                {
                    Node.GraphViewer.DisconnectPort(port: connectorPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge;
                if (connectorPort.IsInput())
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               Model.OutputPort,
                               connectorPort
                           );
                }
                else
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               outputPort: connectorPort,
                               inputPort: Model.InputPort
                           );
                }

                // Register default edge callbacks to the edge.
                DefaultEdgeCallbacks.Register(edge: edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }
    }
}