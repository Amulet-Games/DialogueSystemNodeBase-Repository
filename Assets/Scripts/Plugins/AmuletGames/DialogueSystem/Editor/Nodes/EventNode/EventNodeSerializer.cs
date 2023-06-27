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
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public EventNodeSerializer(EventNode node, EventNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            EventNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveEventModifierGroup();

            AddData();

            void SavePorts()
            {
                View.InputDefaultPort.Save(data.InputPortData);
                View.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveEventModifierGroup()
            {
                View.EventModifierGroupView.Save(data.EventModifierGroupData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EventNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadEventModifierGroup();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(data.InputPortData);
                View.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadEventModifierGroup()
            {
                View.EventModifierGroupView.Load(data.EventModifierGroupData);
            }
        }
    }
}
