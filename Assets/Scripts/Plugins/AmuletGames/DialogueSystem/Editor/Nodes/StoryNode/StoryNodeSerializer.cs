namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeSerializer : NodeSerializerFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public StoryNodeSerializer(StoryNode node, StoryNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            StoryNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();

            AddData();

            void SavePorts()
            {
                View.InputDefaultPort.Save(data.InputPortData);
                View.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                data.SecondLineTriggerTypeEnumIndex = View.SecondLineTriggerTypeEnumContainer.Value;
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                data.CsvGUID = View.CsvGUID;
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StoryNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(data.InputPortData);
                View.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                View.SecondLineTriggerTypeEnumContainer.Load(data.SecondLineTriggerTypeEnumIndex);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                View.CsvGUID = data.CsvGUID;
            }
        }
    }
}