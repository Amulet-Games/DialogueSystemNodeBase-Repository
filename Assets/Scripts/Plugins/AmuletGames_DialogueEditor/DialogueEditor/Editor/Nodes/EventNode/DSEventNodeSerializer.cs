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
            DSEventNodeModel newNodeModel = new DSEventNodeModel(Node);

            SaveBaseValues(newNodeModel);

            SavePortsGuid();

            SaveEventMolder();

            return newNodeModel;

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
        /// <inheritdoc />
        public override void LoadNode(DSEventNodeModel source)
        {
            LoadBaseValues(source);

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
