namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeSerializer : NodeSerializerFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public StartNodeSerializer(StartNode node, StartNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel)
        {
            StartNodeModel model = new();

            SaveBaseValues(model: model);

            SavePorts();

            AddToDsModel();

            void SavePorts()
            {
                View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StartNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            void LoadPorts()
            {
                View.OutputDefaultPort.Load(model.OutputPortModel);
            }
        }
    }
}