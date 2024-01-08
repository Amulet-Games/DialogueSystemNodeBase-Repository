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
            Data.InputPortData = PortManager.Instance.Save(View.InputPort);
            Data.TrueOutputPortData =  PortManager.Instance.Save(View.TrueOutputPort);
            Data.FalseOutputPortData = PortManager.Instance.Save(View.FalseOutputPort);
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
            PortManager.Instance.Load(View.InputPort, Data.InputPortData);
            PortManager.Instance.Load(View.TrueOutputPort, Data.TrueOutputPortData);
            PortManager.Instance.Load(View.FalseOutputPort, Data.FalseOutputPortData);
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