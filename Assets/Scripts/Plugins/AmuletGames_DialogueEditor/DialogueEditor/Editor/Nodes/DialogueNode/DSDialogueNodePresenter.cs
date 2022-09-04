using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;

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
        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public void CreateNodeElements()
        {
            AddContentButton_OptionEntry();

            AddImagesPreviewSegment();

            AddSpeakerNameSegment();

            AddTextlineSegment();

            void AddContentButton_OptionEntry()
            {
                DSIntegrantsMaker.GetNewContentButton(Node, DSStringsConfig.AddEntryLabelText, DSAssetsConfig.AddOptionEntryButtonIconImage, DSStylesConfig.Integrant_ContentButton_AddOptionEntry_Image, AddOptionEntryAction);
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


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.AddInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
            Model.ContinueOutputPort = DSPortsMaker.AddOutputPort(Node, false, DSStringsConfig.DialogueNodeContinueOuputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void AddOptionEntryAction()
        {
            // Ask option window to get a new option entry.
            Model.OptionWindow.GetNewOptionEntry(null);

            // Refresh Ports Layout.
            Node.RefreshPortsLayout();
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <summary>
        /// Is the node's input ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if input ports are connected and vice versa.</returns>
        public override bool IsInputPortConnected() => Model.InputPort.connected;


        /// <summary>
        /// Is the node's output ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if output ports are connected and vice versa.</returns>
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