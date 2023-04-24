namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeSerializer : NodeSerializerFrameBase
    <
        EndNode,
        EndNodeModel,
        EndNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node serializer module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public EndNodeSerializer(EndNode node, EndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            EndNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            AddData();

            void SavePorts()
            {
                Model.InputDefaultPort.Save(data.InputPortData);
            }

            void AddData()
            {
                dsData.EndNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EndNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            void LoadPorts()
            {
                Model.InputDefaultPort.Load(data.InputPortData);
            }
        }
    }
}