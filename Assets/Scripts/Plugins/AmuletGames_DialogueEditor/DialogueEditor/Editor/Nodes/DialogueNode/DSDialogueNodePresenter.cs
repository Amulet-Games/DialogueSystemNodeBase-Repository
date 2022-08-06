using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSDialogueNodePresenter : DSNodePresenterFrameBase<DSDialogueNode, DSDialogueNodeModel>
    {
        /// <summary>
        /// Reference of the graph module in the dialogue system.
        /// </summary>
        GraphView graphView;

        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSDialogueNodePresenter(DSDialogueNode node, DSDialogueNodeModel model, DSGraphView graphView)
        {
            Node = node;
            Model = model;
            this.graphView = graphView;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public void CreateNodeElements()
        {
            AddContentButton_ChoiceEntry();

            AddImagesPreviewSegment();

            AddSpeakerNameSegment();

            AddTextlineSegment();

            void AddContentButton_ChoiceEntry()
            {
                DSIntegrantsMaker.GetNewContentButton(Node, "Add Entry", DSAssetsConfig.addChoiceEntryButtonIconImage, DSStylesConfig.integrant_ContentButton_AddChoiceEntry_Image, AddChoiceEntryAction);
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
            Model.InputPort = DSPortsMaker.AddInputPort(Node, "Input", Port.Capacity.Multi, N_NodeType.Dialogue);
            Model.ContinueOutputPort = DSPortsMaker.AddOutputPort(Node, "Continue", Port.Capacity.Single, N_NodeType.Dialogue);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void AddChoiceEntryAction()
        {
            // Create a new choice entry within this node.
            DSEntriesMaker.GetNewChoiceEntry(Node, null, RemoveChoiceEntryAction, Model.ChoiceEntries);

            // Refresh Ports Layout.
            Node.RefreshPortsLayout();
        }


        /// <summary>
        /// Delete the choice entry's port within the connecting dialogue node.
        /// <para>ChoiceEntryRemovedAction - DSEntriesMaker - EntryRemoveButton.</para>
        /// </summary>
        /// <param name="port">The selected port that is going to be deleted.</param>
        public void RemoveChoiceEntryAction(Port port)
        {
            DeleteChoiceEntryPort();

            void DeleteChoiceEntryPort()
            {
                // Find and remove the choice port data that assoicated with the Ouput Port that we are going to delete.
                ChoiceEntry portData = Model.ChoiceEntries.Find(portData => portData.PortGuid == port.name);
                Model.ChoiceEntries.Remove(portData);

                // Find the edge that were come from this Output Port and put them in a list.
                IEnumerable<Edge> portEdges = graphView.edges.ToList().Where(edge => edge.output == port);

                // If there is an edge inside the list, meaning we need to delete it,
                if (portEdges.Any())
                {
                    // Get the edge from the list.
                    Edge firstEdge = portEdges.First();

                    // Disconnect itself from the input node that it's connecting.
                    firstEdge.input.Disconnect(firstEdge);

                    // Disconnect itself from the output node which this edge was originate from.
                    firstEdge.output.Disconnect(firstEdge);

                    // Finally we remove this edge from the graph.
                    graphView.RemoveElement(firstEdge);
                }

                // Remove the Output Port from the node.
                Node.DeletePortElement(port, N_PortContainerType.Output);
            }
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