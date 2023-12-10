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

            SaveConditionModifierGroup();
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
        /// Save the condition modifier group.
        /// </summary>
        void SaveConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Save(View.ConditionModifierGroupView, Model.ConditionModifierGroupModel);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(BooleanNode node, BooleanNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadConditionModifierGroup();
        }

        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortManager.Instance.Load(View.InputDefaultPort, Model.InputPortModel);
            PortManager.Instance.Load(View.TrueOutputDefaultPort, Model.TrueOutputPortModel);
            PortManager.Instance.Load(View.FalseOutputDefaultPort, Model.FalseOutputPortModel);
        }


        /// <summary>
        /// Load the condition modifier group.
        /// </summary>
        void LoadConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Load(
                View.ConditionModifierGroupView,
                Model.ConditionModifierGroupModel,
                Node.GraphViewer
            );
        }
    }
}