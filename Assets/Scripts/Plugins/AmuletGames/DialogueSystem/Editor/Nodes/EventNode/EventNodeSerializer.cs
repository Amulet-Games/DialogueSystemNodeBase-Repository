namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeSerializer : NodeSerializerFrameBase
    <
        EventNode,
        EventNodeView,
        EventNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(EventNode node, EventNodeData data)
        {
            base.Save(node, data);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveEventModifierGroup();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Data.InputPortData = PortManager.Instance.Save(View.InputDefaultPort);
            Data.OutputPortData = PortManager.Instance.Save(View.OutputDefaultPort);
        }


        /// <summary>
        /// Save the event modifier group.
        /// </summary>
        void SaveEventModifierGroup()
        {
            new EventModifierGroupSerializer().Save(View.EventModifierGroupView, Data.EventModifierGroupData);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EventNode node, EventNodeData data)
        {
            base.Load(node, data);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadEventModifierGroup();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            PortManager.Instance.Load(View.InputDefaultPort, Data.InputPortData);
            PortManager.Instance.Load(View.OutputDefaultPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the event modifier group.
        /// </summary>
        void LoadEventModifierGroup()
        {
            new EventModifierGroupSerializer().Load(View.EventModifierGroupView, Data.EventModifierGroupData);
        }
    }
}
