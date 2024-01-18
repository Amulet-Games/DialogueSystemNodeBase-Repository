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
            var serializer = new PortSerializer();
            serializer.Save(View.InputPort, Data.InputPortData);
            serializer.Save(View.OutputPort, Data.OutputPortData);
        }


        /// <summary>
        /// Save the event modifier group.
        /// </summary>
        void SaveEventModifierGroup()
        {
            new EventModifierGroupSerializer().Save(View.EventModifierGroup, Data.EventModifierGroupData);
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
            var serializer = new PortSerializer();
            serializer.Load(View.InputPort, Data.InputPortData);
            serializer.Load(View.OutputPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the event modifier group.
        /// </summary>
        void LoadEventModifierGroup()
        {
            new EventModifierGroupSerializer().Load(View.EventModifierGroup, Data.EventModifierGroupData);
        }
    }
}
