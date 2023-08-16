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
        /// <inheritdoc />
        public override void Save(EventNode node, EventNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveEventModifierGroup();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveEventModifierGroup()
            {
                node.View.EventModifierGroupView.Save(model.EventModifierGroupModel);
            }
        }


        /// <inheritdoc />
        public override void Load(EventNode node, EventNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadEventModifierGroup();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadEventModifierGroup()
            {
                node.View.EventModifierGroupView.Load(model.EventModifierGroupModel);
            }
        }
    }
}
