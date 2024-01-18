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
            var serializer = new PortSerializer();
            serializer.Save(View.InputPort, Data.InputPortData);
            serializer.Save(View.TrueOutputPort, Data.TrueOutputPortData);
            serializer.Save(View.FalseOutputPort, Data.FalseOutputPortData);
        }


        /// <summary>
        /// Save the condition modifier group.
        /// </summary>
        void SaveConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Save(View.ConditionModifierGroup, Data.ConditionModifierGroupData);
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
            var serializer = new PortSerializer();
            serializer.Load(View.InputPort, Data.InputPortData);
            serializer.Load(View.TrueOutputPort, Data.TrueOutputPortData);
            serializer.Load(View.FalseOutputPort, Data.FalseOutputPortData);
        }


        /// <summary>
        /// Load the condition modifier group.
        /// </summary>
        void LoadConditionModifierGroup()
        {
            new ConditionModifierGroupSerializer().Load
            (
                View.ConditionModifierGroup,
                Data.ConditionModifierGroupData,
                Node.GraphViewer
            );
        }
    }
}