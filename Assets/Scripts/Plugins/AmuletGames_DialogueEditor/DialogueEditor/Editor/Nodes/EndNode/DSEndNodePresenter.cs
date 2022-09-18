using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEndNodePresenter : DSNodePresenterFrameBase<DSEndNode, DSEndNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSEndNodePresenter(DSEndNode node, DSEndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            // Create a new graphEndHandle type enum field within this node.
            Node.mainContainer.Add(DSEnumFieldsMaker.GetNewEnumField
            (
                Model.dialogueOverHandleType_EnumContainer,
                DSStylesConfig.EndNode_GraphEndHandleType_EnumField
            ));
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.GetNewInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
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
                result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                if (CreationDetails.HorizontalAlignType == C_Alignment_HorizontalType.Middle)
                {
                    // width offset.
                    result.x -= Node.localBound.width / 2;
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
                Node.GraphView.ConnectPorts(connectorPort, Model.InputPort);
            }
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <inheritdoc />
        public override bool IsInputPortConnected() => Model.InputPort.connected;


        /// <inheritdoc />
        public override bool IsOutputPortConnected() => false;
    }
}