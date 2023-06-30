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
        public override void Save(DialogueSystemModel dsModel)
        {
            EventNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveEventModifierGroup();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveEventModifierGroup()
            {
                View.EventModifierGroupView.Save(model.EventModifierGroupModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EventNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            LoadEventModifierGroup();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadEventModifierGroup()
            {
                View.EventModifierGroupView.Load(model.EventModifierGroupModel);
            }
        }
    }
}
