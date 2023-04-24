using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodePresenter : NodePresenterFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node presenter module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public StartNodePresenter(StartNode node, StartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            base.CreateContentElements();
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.OutputDefaultPort = DefaultPort.CreateElements<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreationConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.Instance.DefaultPort_Output_LabelText
            );

            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        public override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultOutput = Model.OutputDefaultPort;

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
            evt.menu.AppendAction
            (
                actionName: StringConfig.Instance.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action => defaultOutput.Disconnect(Node.GraphViewer),
                status: defaultOutput.connected
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

                result.y -= (Node.titleContainer.worldBound.height
                          + Model.OutputDefaultPort.localBound.position.y
                          + NodeConfig.ManualCreateYOffset)
                          / Node.GraphViewer.scale;

                result.x -= details.HorizontalAlignmentType == HorizontalAlignmentType.MIDDLE
                    ? Node.localBound.width / 2
                    : Node.localBound.width;

                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                var port = details.ConnectorPort;

                if (port.connected)
                {
                    port.Disconnect(Node.GraphViewer);
                }

                var edge = EdgeManager.Instance.Connect
                (
                    output: Model.OutputDefaultPort,
                    input: (DefaultPort)port
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