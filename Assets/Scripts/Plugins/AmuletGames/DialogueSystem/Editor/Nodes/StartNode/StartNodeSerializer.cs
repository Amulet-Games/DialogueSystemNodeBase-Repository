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
        /// Constructor of the start node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StartNodeSerializer(StartNode node, StartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            StartNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            AddData();

            void SavePorts()
            {
                Model.OutputDefaultPort.Save(data.OutputPortData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StartNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            void LoadPorts()
            {
                Model.OutputDefaultPort.Load(data.OutputPortData);
            }
        }
    }
}