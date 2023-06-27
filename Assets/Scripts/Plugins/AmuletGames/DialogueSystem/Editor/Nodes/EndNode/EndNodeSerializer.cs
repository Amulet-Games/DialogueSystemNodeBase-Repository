namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeSerializer : NodeSerializerFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public EndNodeSerializer(EndNode node, EndNodeView view)
        {
            Node = node;
            View = view;
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
                View.InputDefaultPort.Save(data.InputPortData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
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
                View.InputDefaultPort.Load(data.InputPortData);
            }
        }
    }
}