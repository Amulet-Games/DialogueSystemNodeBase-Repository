namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(BooleanNode node, BooleanNodeModel model)
        {
            base.Save(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveBooleanNodeStitcher();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Model.InputPortModel = PortManager.Instance.Save(View.InputDefaultPort);
            Model.TrueOutputPortModel =  PortManager.Instance.Save(View.TrueOutputDefaultPort);
            Model.FalseOutputPortModel = PortManager.Instance.Save(View.FalseOutputDefaultPort);
        }


        /// <summary>
        /// Save the boolean node stitcher.
        /// </summary>
        void SaveBooleanNodeStitcher()
        {
            View.booleanNodeStitcher.SaveStitcherValues(Model.BooleanNodeStitcherModel);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(BooleanNode node, BooleanNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadBooleanNodeStitcher();
        }

        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.TrueOutputDefaultPort.Load(Model.TrueOutputPortModel);
            View.FalseOutputDefaultPort.Load(Model.FalseOutputPortModel);
        }


        /// <summary>
        /// Load the boolean node stitcher.
        /// </summary>
        void LoadBooleanNodeStitcher()
        {
            View.booleanNodeStitcher.LoadStitcherValues(Model.BooleanNodeStitcherModel);
        }
    }
}