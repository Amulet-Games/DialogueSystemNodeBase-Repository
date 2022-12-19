namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeSerializer : NodeSerializerFrameBase
    <
        StoryNode,
        StoryNodeModel,
        StoryNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public StoryNodeSerializer(StoryNode node, StoryNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new StoryNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void AddData()
            {
                dsData.StoryNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(StoryNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.OutputPort.name = data.OutputPortGUID;
            }
        }
    }
}