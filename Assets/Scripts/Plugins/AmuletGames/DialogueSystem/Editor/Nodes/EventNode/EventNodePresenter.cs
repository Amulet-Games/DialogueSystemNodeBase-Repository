using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodePresenter : NodePresenterFrameBase
    <
        EventNode,
        EventNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public EventNodePresenter(EventNode node, EventNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            SetupContentButton();

            SetupEventModifierModelGroup();

            CreateEventModifier();

            void SetupContentButton()
            {
                var contentButton = ContentButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.ContentButton_AddEvent_LabelText,
                    buttonIconSprite: ConfigResourcesManager.Instance.SpriteConfig.AddEventModifierButtonIconSprite
                );

                new ContentButtonCallback(
                    isAlert: true,
                    contentButton: contentButton,
                    clickEvent: ContentButtonClickEvent).RegisterEvents();

                Node.titleContainer.Add(contentButton);
            }

            void SetupEventModifierModelGroup()
            {
                EventModifierModelGroupPresenter.CreateElement(
                    model: Model.EventModifierModelGroupModel);

                Node.ContentContainer.Add(Model.EventModifierModelGroupModel.MainContainer);
            }

            void CreateEventModifier()
            {
                Model.EventModifierModelGroupModel.CreateModifier();
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


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        /// <param name="evt">The registering event</param>
        public void ContentButtonClickEvent(ClickEvent evt)
        {
            Model.EventModifierModelGroupModel.CreateModifier();
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
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
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