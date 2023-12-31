namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionRootNode node, OptionRootNodeData data)
        {
            base.Save(node, data);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveRootTitleTextField();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Data.InputPortData = PortManager.Instance.Save(View.InputDefaultPort);
            Data.OutputOptionPortData = PortManager.Instance.Save(View.OutputOptionPort);
            View.OutputOptionPortGroupView.Save(Data.OutputOptionPortGroupData);
        }


        /// <summary>
        /// Save the root title text field.
        /// </summary>
        void SaveRootTitleTextField()
        {
            View.RootTitleFieldView.Save(Data.RootTitleText);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionRootNode node, OptionRootNodeData data)
        {
            base.Load(node, data);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadRootTitleTextField();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortManager.Instance.Load(View.InputDefaultPort, Data.InputPortData);
            PortManager.Instance.Load(View.OutputOptionPort, Data.OutputOptionPortData);
            View.OutputOptionPortGroupView.Load(Node, Data.OutputOptionPortGroupData);
        }


        /// <summary>
        /// Load the root title text field.
        /// </summary>
        void LoadRootTitleTextField()
        {
            View.RootTitleFieldView.Load(Data.RootTitleText);
        }
    }
}