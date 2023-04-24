using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node presenter module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public BooleanNodePresenter(BooleanNode node, BooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            // Create all the root elements required in the node stitcher.
            Model.booleanNodeStitcher.CreateRootElements(node: Node);
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

            Model.TrueOutputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_True_LabelText
            );

            Model.FalseOutputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_False_LabelText,
                isSiblings: true
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.TrueOutputDefaultPort);
            Node.Add(Model.FalseOutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var defaultTrueOutput = Model.TrueOutputDefaultPort;
            var defaultFalseOutput = Model.FalseOutputDefaultPort;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(Node.GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect True Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectTrueOutputPort_LabelText,
                action: action => defaultTrueOutput.Disconnect(Node.GraphViewer),
                status: defaultTrueOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect False Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectFalseOutputPort_LabelText,
                action: action => defaultFalseOutput.Disconnect(Node.GraphViewer),
                status: defaultFalseOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            var isAnyConnected = defaultInput.connected
                              || defaultTrueOutput.connected
                              || defaultFalseOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(Node.GraphViewer);

                    defaultTrueOutput.Disconnect(Node.GraphViewer);

                    defaultFalseOutput.Disconnect(Node.GraphViewer);
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
                                  + Model.TrueOutputDefaultPort.localBound.position.y
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
                    output: !isInput ? port : Model.TrueOutputDefaultPort,
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