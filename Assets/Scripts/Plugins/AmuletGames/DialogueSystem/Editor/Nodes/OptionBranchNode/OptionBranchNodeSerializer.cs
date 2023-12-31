namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeSerializer : NodeSerializerFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionBranchNode node, OptionBranchNodeData data)
        {
            base.Save(node, data);

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
            Data.OutputPortData = PortManager.Instance.Save(View.OutputDefaultPort);
            Data.InputOptionPortData = PortManager.Instance.Save(View.InputOptionPort);
        }


        /// <summary>
        /// Save the branch title text field.
        /// </summary>
        void SaveBranchTitleTextField()
        {
            View.BranchTitleFieldView.Save(Data.BranchTitleText);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionBranchNode node, OptionBranchNodeData data)
        {
            base.Load(node, data);

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
            PortManager.Instance.Load(View.InputOptionPort, Data.InputOptionPortData);
            PortManager.Instance.Load(View.OutputDefaultPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the branch title text field.
        /// </summary>
        void LoadBranchTitleTextField()
        {
            View.BranchTitleFieldView.Load(Data.BranchTitleText);
        }
    }
}