namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeSerializer : NodeSerializerFrameBase
    <
        EventNode,
        EventNodeModel,
        EventNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node serializer module class.
        /// </summary>
        /// <param name="node">The connecting node module to set for.</param>
        /// <param name="model">The connecting model module to set for.</param>
        public EventNodeSerializer(EventNode node, EventNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new EventNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveEventMolder();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void SaveEventMolder()
            {
                Model.EventMolder.SaveMolderValues(data.EventMolderData);
            }

            void AddData()
            {
                dsData.EventNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(EventNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadEventMolder();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.OutputPort.name = data.OutputPortGUID;
            }

            void LoadEventMolder()
            {
                Model.EventMolder.LoadMolderValues(data.EventMolderData);
            }
        }
    }
}
