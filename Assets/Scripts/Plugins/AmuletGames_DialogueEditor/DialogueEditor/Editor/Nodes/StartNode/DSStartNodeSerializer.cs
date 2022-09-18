
namespace AG
{
    public class DSStartNodeSerializer : DSNodeSerializerFrameBase<DSStartNode, DSStartNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of start node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSStartNodeSerializer(DSStartNode node, DSStartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new start node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected start node model.</returns>
        public DSStartNodeModel SaveNode()
        {
            DSStartNodeModel newNodeModel;

            CreateNewStartNodeModel();

            SaveBaseDetails(newNodeModel);

            SavePortsGuid();

            return newNodeModel;

            void CreateNewStartNodeModel()
            {
                newNodeModel = new DSStartNodeModel();
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new start node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSStartNodeModel source)
        {
            LoadBaseDetails(source);

            LoadPortsGuid();

            void LoadPortsGuid()
            {
                Model.OutputPort.name = source.SavedOutputPortGuid;
            }
        }
    }
}