using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodePresenter : NodePresenterFrameBase
    <
        StoryNode,
        StoryNodeModel
    >
    {
        /// <summary>
        /// A box container that store all the visual elements related to the second textline content.
        /// </summary>
        Box secondContentBox;


        /// <summary>
        /// A box container that store all the visual elements related to the delta time trigger type and its duration.
        /// </summary>
        Box deltaTimeDurationCellBox;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StoryNodePresenter(StoryNode node, StoryNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Input_LabelText
            );

            Model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Output_LabelText
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            PostProcessSetupApplyDesign();

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


        // ----------------------------- Post Process Setup Apply Design -----------------------------
        void PostProcessSetupApplyDesign()
        {
            var margin = 10;

            SetupPreferenceImage();

            SetupGraphViewerZoom();

            DisablePerferenceNode();

            CreateSampleNode();

            void SetupPreferenceImage()
            {
                Image preferenceImage;
                preferenceImage = CommonImagePresenter.CreateElement(imageUSS01: StyleConfig.Instance.StoryNode_PreferenceImage_Image);
                Node.ContentContainer.Add(preferenceImage);

                preferenceImage.sprite = ConfigResourcesManager.Instance.SpriteConfig.ApplyDesignSampleImage;
                preferenceImage.style.opacity = 0.6f;

                preferenceImage.style.marginBottom = margin;
                preferenceImage.style.marginTop = margin;
                preferenceImage.style.marginLeft = margin;
                preferenceImage.style.marginRight = margin;
                Node.ContentContainer.style.backgroundColor = new Color(r: 1, g: 1, b: 1, a: 0.35f);


                Node.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
                Node.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

                Node.capabilities = Capabilities.Movable;
            }
            
            void SetupGraphViewerZoom()
            {
                Node.GraphViewer.SetupZoom(ContentZoomer.DefaultMinScale, 6f);
            }

            void DisablePerferenceNode()
            {
                Node.SetEnabled(false);
            }

            void CreateSampleNode()
            {
                Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    var details = new NodeCreateDetails(
                        horizontalAlignType: HorizontalAlignmentType.FREE);

                    var createPosition = Node.localBound.position;
                    createPosition.x += margin;
                    createPosition.y += Node.titleContainer.layout.height + Node.inputContainer.parent.layout.height + margin;
                    details.SetPositionCreate(value: createPosition);

                    var target = new EventNode(details: details, graphViewer: Node.GraphViewer);

                    target.capabilities = Capabilities.Movable;
                    target.SetEnabled(false);
                    target.style.opacity = 1;
                    target.titleContainer.ElementAt(index: 1).style.backgroundColor = new Color(0.357f, 0.537f, 0.75f, 1);

                    target.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    target.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    target.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
                    target.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

                    Node.BringToFront();

                    // Unregister the action once the setup is done.
                    Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }
    }
}