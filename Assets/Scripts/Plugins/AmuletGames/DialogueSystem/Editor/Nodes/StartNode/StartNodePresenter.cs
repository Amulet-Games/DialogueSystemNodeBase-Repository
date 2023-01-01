using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

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
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public StartNodePresenter(StartNode node, StartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
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


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override  void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectOutputPortAction();

            AppendDisconnectAllPortsAction();

            void AppendDisconnectOutputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: Model.OutputPort.connected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Output port.
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

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                if (details.HorizontalAlignType == C_Alignment_HorizontalType.Middle)
                {
                    // Width offset.
                    result.x -= Node.localBound.width / 2;
                }
                else
                {
                    // Width offset.
                    result.x -= Node.localBound.width;
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
                Edge edge = Node.GraphViewer.ConnectPorts
                            (
                                outputPort: Model.OutputPort,
                                inputPort: connectorPort
                            );

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