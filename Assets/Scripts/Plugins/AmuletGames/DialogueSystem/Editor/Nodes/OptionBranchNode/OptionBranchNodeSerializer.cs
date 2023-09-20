namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeSerializer : NodeSerializerFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionBranchNode node, OptionBranchNodeModel model)
        {
            base.Save(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveBranchTitleTextField();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Model.OutputPortModel = PortManager.Instance.Save(View.OutputDefaultPort);
            Model.InputOptionPortModel = PortManager.Instance.Save(View.InputOptionPort);
        }


        /// <summary>
        /// Save the branch title text field.
        /// </summary>
        void SaveBranchTitleTextField()
        {
            View.BranchTitleFieldView.Save(Model.BranchTitleText);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionBranchNode node, OptionBranchNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadBranchTitleTextField();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortManager.Instance.Load(View.InputOptionPort, Model.InputOptionPortModel);
            PortManager.Instance.Load(View.OutputDefaultPort, Model.OutputPortModel);
        }


        /// <summary>
        /// Load the branch title text field.
        /// </summary>
        void LoadBranchTitleTextField()
        {
            View.BranchTitleFieldView.Load(Model.BranchTitleText);
        }
    }
}