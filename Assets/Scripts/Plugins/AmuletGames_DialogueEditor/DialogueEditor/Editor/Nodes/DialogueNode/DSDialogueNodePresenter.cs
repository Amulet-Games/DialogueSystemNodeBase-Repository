using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSDialogueNodePresenter : DSNodePresenterFrameBase<DSDialogueNode, DSDialogueNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSDialogueNodePresenter(DSDialogueNode node, DSDialogueNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_OptionEntry();

            AddImagesPreviewSegment();

            AddSpeakerNameSegment();

            AddTextlineSegment();

            void AddContentButton_OptionEntry()
            {
                DSIntegrantsMaker.GetNewContentButton
                (
                    Node,
                    DSStringsConfig.AddEntryLabelText,
                    DSAssetsConfig.AddOptionEntryButtonIconImage,
                    DSStylesConfig.Integrant_ContentButton_AddOptionEntry_Image,
                    ContentButtonClickedAction
                );
            }

            void AddImagesPreviewSegment()
            {
                Model.DualPortraitsSegment.SetupSegment(Node);
            }

            void AddSpeakerNameSegment()
            {
                Model.SpeakerNameSegment.SetupSegment(Node);
            }

            void AddTextlineSegment()
            {
                Model.TextlineSegment.SetupSegment(Node);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.GetNewInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
            Model.ContinueOutputPort = DSPortsMaker.GetNewOutputPort(Node, false, DSStringsConfig.DialogueNodeContinueOuputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void ContentButtonClickedAction()
        {
            // Create a new option entry within the node's option window component.
            Model.OptionWindow.GetNewOptionEntry(null);

            // Refresh Ports Layout.
            Node.RefreshPortsLayout();
        }


        /// <inheritdoc />
        public override void NodeManualCreationPreSetupAction()
        {
            if (CreationDetails.CreationConnectorType == N_NodeCreationConnectorType.OptionChannel)
            {
                // Create a new option entry before setting up the connection to the connector port
                // in the later setup action. 
                ContentButtonClickedAction();
            }
        }


        /// <inheritdoc />
        public override void NodeManualCreationSetupAction()
        {
            if (CreationDetails.CreationConnectorType == N_NodeCreationConnectorType.OptionChannel)
            {
                // Ask option window to handle this action.
                Model.OptionWindow.NodeManualCreationSetupAction(CreationDetails.ConnectorPort);
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
                        result.y -= (Node.titleContainer.worldBound.height + Model.ContinueOutputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

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
                    Node.GraphView.ConnectPorts(Model.ContinueOutputPort, connectorPort);
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
        public override bool IsOutputPortConnected()
        {
            // Try to find any visual elements that are type ports.
            foreach (Port port in Node.outputContainer.Children())
            {
                // Skip the port that isn't connecting to any nodes.
                if (port.connected)
                {
                    return true;
                }
            }

            return false;
        }
    }
}