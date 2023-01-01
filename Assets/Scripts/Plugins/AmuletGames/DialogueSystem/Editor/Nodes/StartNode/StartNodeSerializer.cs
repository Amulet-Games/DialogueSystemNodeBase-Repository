namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeSerializer : NodeSerializerFrameBase
    <
        StartNode,
        StartNodeModel,
        StartNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public StartNodeSerializer(StartNode node, StartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            StartNodeData data = new();

            SaveBaseValues(data: data);

            SavePortsGUID();

            AddData();

            void SavePortsGUID()
            {
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void AddData()
            {
                dsData.StartNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(StartNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            void LoadPortsGUID()
            {
                Model.OutputPort.name = data.OutputPortGUID;
            }
        }
    }
}