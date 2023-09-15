namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeSerializer : NodeSerializerFrameBase
    <
        EventNode,
        EventNodeView,
        EventNodeModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(EventNode node, EventNodeModel model)
        {
            base.Save(node, model);

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
            Model.InputPortModel = PortManager.Instance.Save(View.InputDefaultPort);
            Model.OutputPortModel = PortManager.Instance.Save(View.OutputDefaultPort);
        }


        /// <summary>
        /// Save the event modifier group.
        /// </summary>
        void SaveEventModifierGroup()
        {
            new EventModifierGroupSerializer().Save(View.EventModifierGroupView, Model.EventModifierGroupModel);
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EventNode node, EventNodeModel model)
        {
            base.Load(node, model);

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
            PortManager.Instance.Load(View.InputDefaultPort, Model.InputPortModel);
            PortManager.Instance.Load(View.OutputDefaultPort, Model.OutputPortModel);
        }


        /// <summary>
        /// Load the event modifier group.
        /// </summary>
        void LoadEventModifierGroup()
        {
            new EventModifierGroupSerializer().Load(View.EventModifierGroupView, Model.EventModifierGroupModel);
        }
    }
}
