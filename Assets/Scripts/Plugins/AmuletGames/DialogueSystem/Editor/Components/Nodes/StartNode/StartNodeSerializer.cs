namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeSerializer : NodeSerializerFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(StartNode node, StartNodeData data)
        {
            base.Load(node, data);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            PortSerializer.Save(port: View.OutputPort, data: Data.OutputPortData);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StartNode node, StartNodeData data)
        {
            base.Load(node, data);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortSerializer.Load(View.OutputPort, Data.OutputPortData);
        }
    }
}