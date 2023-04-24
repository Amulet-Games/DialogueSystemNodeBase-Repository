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
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public EventNodeSerializer(EventNode node, EventNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            EventNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveEventModifierModelGroup();

            AddData();

            void SavePorts()
            {
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveEventModifierModelGroup()
            {
                Model.EventModifierModelGroupModel.Save(data.EventModifierModelGroupData);
            }

            void AddData()
            {
                dsData.EventNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EventNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadEventModifierModelGroup();

            void LoadPorts()
            {
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadEventModifierModelGroup()
            {
                Model.EventModifierModelGroupModel.Load(data.EventModifierModelGroupData);
            }
        }
    }
}
