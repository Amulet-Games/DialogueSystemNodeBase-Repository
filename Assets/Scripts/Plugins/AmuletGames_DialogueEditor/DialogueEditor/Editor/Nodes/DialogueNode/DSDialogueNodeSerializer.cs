using System.Collections.Generic;

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
        public DSDialogueNodeModel SaveNode()
        {
            DSDialogueNodeModel newNodeModel;

            CreateNewDialogueNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveOptionWindow();

            SaveImagesPreviewSegment();

            SaveSpeakerNameSegment();

            SaveTextlineSegment();

            return newNodeModel;

            void CreateNewDialogueNodeModel()
            {
                newNodeModel = new DSDialogueNodeModel(Node);
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

            void SaveOptionWindow()
            {
                newNodeModel.OptionWindow.SaveWindowValues(Model.OptionWindow);
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

            LoadOptionEntries();

            LoadDualPortraitsSegment();

            LoadSpeakerNameSegment();

            LoadTextlineSegment();

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

            void LoadOptionEntries()
            {
                Model.OptionWindow.LoadWindowValues(source.OptionWindow);
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

            void RefreshPortsLayout()
            {
                // Refresh Ports Layout.
                Node.RefreshPortsLayout();
            }
        }
    }
}