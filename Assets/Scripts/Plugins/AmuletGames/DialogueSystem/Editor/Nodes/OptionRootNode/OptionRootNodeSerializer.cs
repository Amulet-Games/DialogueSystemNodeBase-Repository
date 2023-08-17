namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionRootNode node, OptionRootNodeModel model)
        {
            base.Save(node, model);

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
            View.InputDefaultPort.Save(Model.InputPortModel);
            View.OutputOptionPort.Save(Model.OutputOptionPortModel);
            View.OutputOptionPortGroupView.Save(Model.OutputOptionPortGroupModel);
        }


        /// <summary>
        /// Save the root title text field.
        /// </summary>
        void SaveRootTitleTextField()
        {
            View.RootTitleTextFieldView.Save(Model.HeadlineText);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionRootNode node, OptionRootNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadRootTitleTextField();

            Node.RefreshPorts();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.OutputOptionPort.Load(Model.OutputOptionPortModel);
            View.OutputOptionPortGroupView.Load(Node, Model.OutputOptionPortGroupModel);
        }


        /// <summary>
        /// Load the root title text field.
        /// </summary>
        void LoadRootTitleTextField()
        {
            View.RootTitleTextFieldView.Load(Model.HeadlineText);
        }
    }
}