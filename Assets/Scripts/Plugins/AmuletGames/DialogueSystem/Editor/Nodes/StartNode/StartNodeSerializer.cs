namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeSerializer : NodeSerializerFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(StartNode node, StartNodeModel model)
        {
            base.Load(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Model.OutputPortModel = PortManager.Instance.Save<DefaultPort, PortModelBase>(View.OutputDefaultPort);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StartNode node, StartNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.OutputDefaultPort.Load(Model.OutputPortModel);
        }
    }
}