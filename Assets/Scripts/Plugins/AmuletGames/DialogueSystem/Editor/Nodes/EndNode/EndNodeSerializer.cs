namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeSerializer : NodeSerializerFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public EndNodeSerializer(EndNode node, EndNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel)
        {
            EndNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(EndNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
            }
        }
    }
}