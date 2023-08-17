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
            View.InputDefaultPort.Save(Model.InputPortModel);
            View.OutputDefaultPort.Save(Model.OutputPortModel);
        }


        /// <summary>
        /// Save the event modifier group.
        /// </summary>
        void SaveEventModifierGroup()
        {
            View.EventModifierGroupView.Save(Model.EventModifierGroupModel);
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
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.OutputDefaultPort.Load(Model.OutputPortModel);
        }


        /// <summary>
        /// Load the event modifier group.
        /// </summary>
        void LoadEventModifierGroup()
        {
            View.EventModifierGroupView.Load(Model.EventModifierGroupModel);
        }
    }
}
