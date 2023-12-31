namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(BooleanNode node, BooleanNodeData data)
        {
            base.Save(node, data);

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
            Data.InputPortData = PortManager.Instance.Save(View.InputDefaultPort);
            Data.TrueOutputPortData =  PortManager.Instance.Save(View.TrueOutputDefaultPort);
            Data.FalseOutputPortData = PortManager.Instance.Save(View.FalseOutputDefaultPort);
        }


        /// <summary>
        /// Save the condition modifier group.
        /// </summary>
        void SaveConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Save(View.ConditionModifierGroupView, Data.ConditionModifierGroupData);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(BooleanNode node, BooleanNodeData data)
        {
            base.Load(node, data);

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
            PortManager.Instance.Load(View.InputDefaultPort, Data.InputPortData);
            PortManager.Instance.Load(View.TrueOutputDefaultPort, Data.TrueOutputPortData);
            PortManager.Instance.Load(View.FalseOutputDefaultPort, Data.FalseOutputPortData);
        }


        /// <summary>
        /// Load the condition modifier group.
        /// </summary>
        void LoadConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Load(
                View.ConditionModifierGroupView,
                Data.ConditionModifierGroupData,
                Node.GraphViewer
            );
        }
    }
}