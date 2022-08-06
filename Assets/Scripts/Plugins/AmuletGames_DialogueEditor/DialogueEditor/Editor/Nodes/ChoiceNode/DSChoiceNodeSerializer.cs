using System.Collections.Generic;

namespace AG
{
    public class DSChoiceNodeSerializer : DSNodeSerializerFrameBase<DSChoiceNode, DSChoiceNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of choice node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSChoiceNodeSerializer(DSChoiceNode node, DSChoiceNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new choice node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected choice node model.</returns>
        public DSChoiceNodeModel SaveNode()
        {
            DSChoiceNodeModel newNodeModel;

            CreateNewChoiceNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveTextlineSegment();

            SaveConditionSegment();

            return newNodeModel;

            void CreateNewChoiceNodeModel()
            {
                newNodeModel = new DSChoiceNodeModel();
            }

            void SaveNodeDetails()
            {
                newNodeModel.SavedNodeGuid = Node.NodeGuid;
                newNodeModel.SavedNodePosition = Node.GetPosition().position;
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
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
        /// Create a new choice node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSChoiceNodeModel source)
        {
            LoadNodeDetails();

            LoadPortsGuid();

            LoadTextlineSegment();

            LoadConditionSegment();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
            }

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
                Model.OutputPort.name = source.SavedOutputPortGuid;
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