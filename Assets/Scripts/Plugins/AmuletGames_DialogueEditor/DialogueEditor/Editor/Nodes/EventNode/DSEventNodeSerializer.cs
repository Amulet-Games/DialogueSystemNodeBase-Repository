using System.Collections;
using System.Collections.Generic;

namespace AG
{
    public class DSEventNodeSerializer : DSNodeSerializerFrameBase<DSEventNode, DSEventNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSEventNodeSerializer(DSEventNode node, DSEventNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new event node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected event node model.</returns>
        public DSEventNodeModel SaveNode()
        {
            DSEventNodeModel newNodeModel;

            CreateNewEventNodeModel();

            SaveBaseDetails(newNodeModel);

            SavePortsGuid();

            SaveEventMolder();

            return newNodeModel;

            void CreateNewEventNodeModel()
            {
                newNodeModel = new DSEventNodeModel();
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
            }

            void SaveEventMolder()
            {
                newNodeModel.EventMolder.SaveMolderValues(Model.EventMolder);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new event node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSEventNodeModel source)
        {
            LoadBaseDetails(source);

            LoadPortsGuid();

            LoadEventMolder();

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
                Model.OutputPort.name = source.SavedOutputPortGuid;
            }

            void LoadEventMolder()
            {
                Model.EventMolder.LoadMolderValues(source.EventMolder);
            }
        }
    }
}
