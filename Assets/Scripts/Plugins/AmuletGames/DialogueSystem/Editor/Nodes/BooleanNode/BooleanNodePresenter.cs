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
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public BooleanNodePresenter(BooleanNode node, BooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            // Create a new condition molder within this node.
            Model.ConditionMolder.GetNewMolder
            (
                node: Node,
                contentBtnText: StringsConfig.AddConditionLabelText,
                contentBtnSprite: AssetsConfig.AddConditionModifierButtonIconSprite,
                contentBtnIconImageUSS01: StylesConfig.Integrant_ContentButton_AddCondition_Image
            );
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

            // True Output port.
            Model.TrueOutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.BooleanNodeTrueOutputLabelText,
                isSiblings: false
            );

            // False Output port.
            Model.FalseOutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.BooleanNodeFalseOutputLabelText,
                isSiblings: true
            );

            // Refresh ports.
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            AppendDisconnectInputPortAction();

            AppendDisconnectTrueOuputPortAction();

            AppendDisconnectFalseOuputPortAction();

            AppendDisconnectAllPortsAction();

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectTrueOuputPortAction()
            {
                Model.TrueOutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectTrueOutputPortLabelText
                );
            }

            void AppendDisconnectFalseOuputPortAction()
            {
                Model.FalseOutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectFalseOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                var isInputPortConnected = Model.InputPort.connected;
                var isTrueOutputPortConnected = Model.TrueOutputPort.connected;
                var isFalseOutputPortConnected = Model.FalseOutputPort.connected;

                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isTrueOutputPortConnected || isFalseOutputPortConnected 
                            ? DropdownMenuAction.Status.Normal 
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    Model.InputPort.DisconnectPort();
                    // Disconnect True Output port.
                    Model.TrueOutputPort.DisconnectPort();
                    // Disconnect False Output port.
                    Model.FalseOutputPort.DisconnectPort();
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
                        result.y -= (Node.titleContainer.worldBound.height + Model.TrueOutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

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
                               outputPort: Model.TrueOutputPort,
                               inputPort: connectorPort
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