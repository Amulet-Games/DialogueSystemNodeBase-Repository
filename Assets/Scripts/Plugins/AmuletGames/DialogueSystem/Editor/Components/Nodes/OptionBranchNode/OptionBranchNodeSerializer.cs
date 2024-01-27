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
            PortSerializer.Save(View.OutputPort, Data.OutputPortData);
            OptionPortCellSerializer.Save(View.InputOptionPortCell, Data.InputOptionPortCellData);
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
            PortSerializer.Load(View.OutputPort, Data.OutputPortData);
            OptionPortCellSerializer.Load(View.InputOptionPortCell, Data.InputOptionPortCellData);
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