using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSDialogueNodeSerializer : DSNodeSerializerFrameBase<DSDialogueNode, DSDialogueNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSDialogueNodeSerializer(DSDialogueNode node, DSDialogueNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new dialogue node's model and save the current model's data into it.
        /// </summary>
        /// <param name="edges">List of edges that are currently in the graph.</param>
        /// <returns>A new copy of selected dialogue node model.</returns>
        public DSDialogueNodeModel SaveNode(List<Edge> edges, int edgesCount)
        {
            DSDialogueNodeModel newNodeModel;

            CreateNewDialogueNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveImagesPreviewSegment();

            SaveSpeakerNameSegment();

            SaveTextlineSegment();

            SaveChoiceEntries();

            return newNodeModel;

            void CreateNewDialogueNodeModel()
            {
                newNodeModel = new DSDialogueNodeModel();
            }

            void SaveNodeDetails()
            {
                newNodeModel.SavedNodeGuid = Node.NodeGuid;
                newNodeModel.SavedNodePosition = Node.GetPosition().position;
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedContinueOutputPortGuid = Model.ContinueOutputPort.name;
            }

            void SaveImagesPreviewSegment()
            {
                newNodeModel.DualPortraitsSegment.SaveSegmentValues(Model.DualPortraitsSegment);
            }

            void SaveSpeakerNameSegment()
            {
                newNodeModel.SpeakerNameSegment.SaveSegmentValues(Model.SpeakerNameSegment);
            }

            void SaveTextlineSegment()
            {
                newNodeModel.TextlineSegment.SaveSegmentValues(Model.TextlineSegment);
            }

            void SaveChoiceEntries()
            {
                List<ChoiceEntry> sourceChoiceEntries = Model.ChoiceEntries;
                for (int i = 0; i < sourceChoiceEntries.Count; i++)
                {
                    // Save the source's port guid id.
                    newNodeModel.ChoiceEntries.Add
                    (
                        ChoiceEntry.SaveEntryValue(sourceChoiceEntries[i], edges, edgesCount)
                    );
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new dialogue node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSDialogueNodeModel source)
        {
            LoadNodeDetails();

            LoadPortsGuid();

            LoadDualPortraitsSegment();

            LoadSpeakerNameSegment();

            LoadTextlineSegment();

            LoadChoiceEntries();

            RefreshPortsLayout();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
            }

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
                Model.ContinueOutputPort.name = source.SavedContinueOutputPortGuid;
            }

            void LoadDualPortraitsSegment()
            {
                Model.DualPortraitsSegment.LoadSegmentValues(source.DualPortraitsSegment);
            }

            void LoadSpeakerNameSegment()
            {
                Model.SpeakerNameSegment.LoadSegmentValues(source.SpeakerNameSegment);
            }

            void LoadTextlineSegment()
            {
                Model.TextlineSegment.LoadSegmentValues(source.TextlineSegment);
            }

            void LoadChoiceEntries()
            {
                // Foreach choice entry saved in dialogue node data.
                for (int i = 0; i < source.ChoiceEntries.Count; i++)
                {
                    // Create a new choice entry and it's visual element on the new dialogue node,
                    // and overwrite the port's data from the loaded node data.

                    DSEntriesMaker.GetNewChoiceEntry(Node, source.ChoiceEntries[i], Node.Presenter.RemoveChoiceEntryAction, Model.ChoiceEntries);
                }
            }

            void RefreshPortsLayout()
            {
                // Refresh Ports Layout.
                Node.RefreshPortsLayout();
            }
        }
    }
}

/*
 void SaveChoiceEntries()
            {
                List<ChoiceEntry> sourceChoiceEntries = Model.ChoiceEntries;
                for (int i = 0; i < sourceChoiceEntries.Count; i++)
                {
                    ChoiceEntry newChoiceEntries = new ChoiceEntry();

                    // Save the Port Guid
                    newChoiceEntries.PortGuid = sourceChoiceEntries[i].PortGuid;

                    // Set Both outputNodeGuid and inputNodeGuid as empty for now
                    newChoiceEntries.OutputNodeGuid = "";
                    newChoiceEntries.InputNodeGuid = "";

                    // Foreach every edges we can find in the graph
                    for (int j = 0; j < edges.Count; j++)
                    {
                        // If this edge is currently connecting nodes togther, and the output port its connecting from
                        // share the same name as the port that we are trying to save,
                        // means that we can find the node Guid of the two nodes that this edge is connecting.
                        if (edges[j].output.name == sourceChoiceEntries[i].PortGuid)
                        {
                            // Save the two nodes' Guid in the data and break out from the loop.
                            newChoiceEntries.OutputNodeGuid = ((DSNodeBase)edges[j].output.node).NodeGuid;
                            newChoiceEntries.InputNodeGuid = ((DSNodeBase)edges[j].input.node).NodeGuid;
                            break;
                        }
                    }

                    newNodeModel.ChoiceEntries.Add(newChoiceEntries);
                }
            }
 */