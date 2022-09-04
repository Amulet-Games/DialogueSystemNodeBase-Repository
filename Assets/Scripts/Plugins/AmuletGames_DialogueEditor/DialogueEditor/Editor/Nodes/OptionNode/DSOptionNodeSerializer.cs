using System.Collections.Generic;

namespace AG
{
    public class DSOptionNodeSerializer : DSNodeSerializerFrameBase<DSOptionNode, DSOptionNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSOptionNodeSerializer(DSOptionNode node, DSOptionNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new option node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected option node model.</returns>
        public DSOptionNodeModel SaveNode()
        {
            DSOptionNodeModel newNodeModel;

            CreateNewOptionNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveOptionTrack();

            SaveTextlineSegment();

            SaveConditionSegment();

            return newNodeModel;

            void CreateNewOptionNodeModel()
            {
                newNodeModel = new DSOptionNodeModel();
            }

            void SaveNodeDetails()
            {
                newNodeModel.SavedNodeGuid = Node.NodeGuid;
                newNodeModel.SavedNodePosition = Node.GetPosition().position;
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
            }

            void SaveOptionTrack()
            {
                newNodeModel.OptionTrack.SaveTrackValues(Model.OptionTrack);
            }

            void SaveTextlineSegment()
            {
                newNodeModel.TextlineSegment.SaveSegmentValues(Model.TextlineSegment);
            }

            void SaveConditionSegment()
            {
                newNodeModel.ConditionSegment.SaveSegmentValues(Model.ConditionSegment);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new option node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSOptionNodeModel source)
        {
            LoadNodeDetails();

            LoadPortsGuid();

            LoadOptionTrack();

            LoadTextlineSegment();

            LoadConditionSegment();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
            }

            void LoadPortsGuid()
            {
                Model.OutputPort.name = source.SavedOutputPortGuid;
            }

            void LoadOptionTrack()
            {
                Model.OptionTrack.LoadTrackValues(source.OptionTrack);
            }

            void LoadTextlineSegment()
            {
                Model.TextlineSegment.LoadSegmentValues(source.TextlineSegment);
            }

            void LoadConditionSegment()
            {
                Model.ConditionSegment.LoadSegmentValues(source.ConditionSegment);
            }
        }
    }
}