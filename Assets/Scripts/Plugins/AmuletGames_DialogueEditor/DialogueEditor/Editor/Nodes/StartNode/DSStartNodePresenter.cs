using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSStartNodePresenter : DSNodePresenterFrameBase<DSStartNode, DSStartNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of start node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSStartNodePresenter(DSStartNode node, DSStartNodeModel model)
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
            Model.OutputPort = DSPortsMaker.GetNewOutputPort(Node, false, DSStringsConfig.NodeOutputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void NodeManualCreationSetupAction()
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                if (CreationDetails.HorizontalAlignType == C_Alignment_HorizontalType.Middle)
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
                Node.SetPosition(new Rect(result, DSVector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connnector port is null then return.
                if (CreationDetails.ConnectorPort == null)
                    return;

                // Create local reference for the connector port.
                Port connectorPort = CreationDetails.ConnectorPort;

                // If the connector port is connecting to another port, disconnect them first.
                if (connectorPort.connected)
                {
                    Node.GraphView.DisconnectPorts(connectorPort);
                }

                // Connect to connector port.
                Node.GraphView.ConnectPorts(Model.OutputPort, connectorPort);
            }
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <inheritdoc />
        public override bool IsInputPortConnected() => false;


        /// <inheritdoc />
        public override bool IsOutputPortConnected() => Model.OutputPort.connected;
    }
}