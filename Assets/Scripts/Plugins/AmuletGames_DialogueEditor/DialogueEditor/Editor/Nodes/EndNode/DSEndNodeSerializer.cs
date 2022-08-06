namespace AG
{
    public class DSEndNodeSerializer : DSNodeSerializerFrameBase<DSEndNode, DSEndNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSEndNodeSerializer(DSEndNode node, DSEndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new end node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected end node model.</returns>
        public DSEndNodeModel SaveNode()
        {
            DSEndNodeModel newNodeModel;

            CreateNewEndNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveGraphEndHandleType();

            return newNodeModel;

            void CreateNewEndNodeModel()
            {
                newNodeModel = new DSEndNodeModel();
            }

            void SaveNodeDetails()
            {
                newNodeModel.SavedNodeGuid = Node.NodeGuid;
                newNodeModel.SavedNodePosition = Node.GetPosition().position;
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
            }

            void SaveGraphEndHandleType()
            {
                newNodeModel.dialogueOverHandleType_EnumContainer.SaveContainerValue(Model.dialogueOverHandleType_EnumContainer);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new end node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSEndNodeModel source)
        {
            LoadNodeDetails();

            LoadPortsGuid();

            LoadGraphEndHandleType();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
            }

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
            }

            void LoadGraphEndHandleType()
            {
                Model.dialogueOverHandleType_EnumContainer.LoadContainerValue(source.dialogueOverHandleType_EnumContainer);
            }
        }
    }
}