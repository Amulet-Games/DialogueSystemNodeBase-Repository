using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSOptionNodePresenter : DSNodePresenterFrameBase<DSOptionNode, DSOptionNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSOptionNodePresenter(DSOptionNode node, DSOptionNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_ConditionModifier();

            AddOptionTrack();

            AddTextlineSegment();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                DSIntegrantsMaker.GetNewContentButton(Node, DSStringsConfig.AddConditionLabelText, DSAssetsConfig.AddConditionModifierButtonIconImage, DSStylesConfig.Integrant_ContentButton_AddCondition_Image, IntegrantButtonPressedAction);
            }

            void AddOptionTrack()
            {
                Model.OptionTrack.SetupTrack(Node);
            }

            void AddTextlineSegment()
            {
                Model.TextlineSegment.SetupSegment(Node);
            }

            void AddConditionSegment()
            {
                Model.ConditionSegment.SetupSegment(Node);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            Model.OutputPort = DSPortsMaker.GetNewOutputPort(Node, false, DSStringsConfig.NodeOutputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void IntegrantButtonPressedAction()
        {
            // Create a new condition modifier within this node.
            DSModifiersMaker.GetNewConditionModifier
            (
                null,
                Model.ConditionSegment.ModifierAddedAction,
                Model.ConditionSegment.ModifierRemovedAction
            );

            // Reveal the condition segment on the connecting node.
            DSElementDisplayUtility.ShowElement(Model.ConditionSegment.MainBox);
        }


        /// <inheritdoc />
        public override void NodeManualCreationSetupAction()
        {
            if (CreationDetails.CreationConnectorType == N_NodeCreationConnectorType.OptionChannel)
            {
                // Ask option track to handle this action.
                Model.OptionTrack.NodeManualCreationSetupAction(Node, CreationDetails.ConnectorPort);
            }
            else
            {
                AlignConnectorPosition();

                ConnectConnectorPort();
            }

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (CreationDetails.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Left:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                        // Width offset.
                        result.x -= Node.localBound.width;

                        break;
                    case C_Alignment_HorizontalType.Middle:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.OptionTrack.Port.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;
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
                Node.GraphView.ConnectPorts(Model.OutputPort, connectorPort);
            }
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <inheritdoc />
        public override bool IsInputPortConnected() => Model.OptionTrack.Port.connected;


        /// <inheritdoc />
        public override bool IsOutputPortConnected() => Model.OutputPort.connected;
    }
}