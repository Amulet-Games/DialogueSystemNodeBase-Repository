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
            Model.InputPortModel = PortManager.Instance.Save(View.InputDefaultPort);
            Model.OutputOptionPortModel = PortManager.Instance.Save(View.OutputOptionPort);
            View.OutputOptionPortGroupView.Save(Model.OutputOptionPortGroupModel);
        }


        /// <summary>
        /// Save the root title text field.
        /// </summary>
        void SaveRootTitleTextField()
        {
            View.RootTitleFieldView.Save(Model.HeadlineText);
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
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortManager.Instance.Load(View.InputDefaultPort, Model.InputPortModel);
            PortManager.Instance.Load(View.OutputOptionPort, Model.OutputOptionPortModel);
            View.OutputOptionPortGroupView.Load(Node, Model.OutputOptionPortGroupModel);
        }


        /// <summary>
        /// Load the root title text field.
        /// </summary>
        void LoadRootTitleTextField()
        {
            View.RootTitleFieldView.Load(Model.HeadlineText);
        }
    }
}