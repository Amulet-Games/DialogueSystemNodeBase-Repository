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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(EndNode node, EndNodeData data)
        {
            base.Save(node, data);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            new PortSerializer().Save(View.InputPort, Data.InputPortData);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EndNode node, EndNodeData data)
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
            new PortSerializer().Load(View.InputPort, Data.InputPortData);
        }
    }
}