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
            PortSerializer.Save(port: View.InputPort, data: Data.InputPortData);
            OptionPortGroupSerializer.Save(group: View.OutputOptionPortGroup, data: Data.OutputOptionPortGroupData);
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
            PortSerializer.Load(View.InputPort, Data.InputPortData);
            OptionPortGroupSerializer.Load(group: View.OutputOptionPortGroup, data: Data.OutputOptionPortGroupData);
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