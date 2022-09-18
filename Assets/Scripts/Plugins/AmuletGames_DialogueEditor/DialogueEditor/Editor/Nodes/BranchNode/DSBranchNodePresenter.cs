using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSBranchNodePresenter : DSNodePresenterFrameBase<DSBranchNode, DSBranchNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of branch node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSBranchNodePresenter(DSBranchNode node, DSBranchNodeModel model)
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
                Node,
                DSStringsConfig.AddConditionLabelText,
                DSAssetsConfig.AddConditionModifierButtonIconImage, 
                DSStylesConfig.Integrant_ContentButton_AddCondition_Image
            );
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.GetNewInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
            Model.TrueOutputPort = DSPortsMaker.GetNewOutputPort(Node, false, DSStringsConfig.BranchNodeTrueOutputLabelText, Port.Capacity.Single);
            Model.FalseOutputPort = DSPortsMaker.GetNewOutputPort(Node, true, DSStringsConfig.BranchNodeFalseOutputLabelText, Port.Capacity.Single);
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

                switch (CreationDetails.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Left:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.TrueOutputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                        // Width offset.
                        result.x -= Node.localBound.width;

                        break;
                    case C_Alignment_HorizontalType.Middle:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;

                        break;
                    case C_Alignment_HorizontalType.Right:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;
                        break;
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
                if (connectorPort.IsInput())
                {
                    Node.GraphView.ConnectPorts(Model.TrueOutputPort, connectorPort);
                }
                else
                {
                    Node.GraphView.ConnectPorts(connectorPort, Model.InputPort);
                }
            }
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <inheritdoc />
        public override bool IsInputPortConnected() => Model.InputPort.connected;


        /// <inheritdoc />
        public override bool IsOutputPortConnected() => Model.FalseOutputPort.connected || Model.TrueOutputPort.connected;
    }
}