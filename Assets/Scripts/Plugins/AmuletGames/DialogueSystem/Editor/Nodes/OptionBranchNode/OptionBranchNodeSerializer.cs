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
            View.OutputDefaultPort.Save(Model.OutputPortModel);
            View.InputOptionPort.Save(Model.InputOptionPortModel);
        }


        /// <summary>
        /// Save the branch title text field.
        /// </summary>
        void SaveBranchTitleTextField()
        {
            View.BranchTitleTextFieldView.Save(Model.HeadlineText);
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
            View.OutputDefaultPort.Load(Model.OutputPortModel);
            View.InputOptionPort.Load(Model.InputOptionPortModel);
        }


        /// <summary>
        /// Load the branch title text field.
        /// </summary>
        void LoadBranchTitleTextField()
        {
            View.BranchTitleTextFieldView.Load(Model.HeadlineText);
        }
    }
}