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
            PortSerializer.Save(port: View.InputPort, data: Data.InputPortData);
            PortSerializer.Save(port: View.OutputPort, data: Data.OutputPortData);
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
            PortSerializer.Load(View.InputPort, Data.InputPortData);
            PortSerializer.Load(View.OutputPort, Data.OutputPortData);
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
