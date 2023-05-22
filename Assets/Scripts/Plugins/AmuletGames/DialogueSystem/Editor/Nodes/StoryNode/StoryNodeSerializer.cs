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
        /// Constructor of the story node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StoryNodeSerializer(StoryNode node, StoryNodeModel model)
        {
            Node = node;
            Model = model;
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
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                data.SecondLineTriggerTypeEnumIndex = Model.SecondLineTriggerTypeEnumContainer.Value;
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                data.CsvGUID = Model.CsvGUID;
            }

            void AddData()
            {
                dsData.StoryNodeData.Add(data);
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
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                Model.SecondLineTriggerTypeEnumContainer.Load(data.SecondLineTriggerTypeEnumIndex);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                Model.CsvGUID = data.CsvGUID;
            }
        }
    }
}