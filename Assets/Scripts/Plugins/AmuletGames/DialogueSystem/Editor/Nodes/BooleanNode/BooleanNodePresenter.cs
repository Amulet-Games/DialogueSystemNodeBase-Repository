using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
        /// Constructor of the boolean node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
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
            Model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            Model.TrueOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_True_LabelText
            );

            Model.FalseOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_False_LabelText,
                isSiblings: true
            );

            Node.Add(Model.InputDefaultPort);
            Node.Add(Model.TrueOutputDefaultPort);
            Node.Add(Model.FalseOutputDefaultPort);
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
        }
    }
}