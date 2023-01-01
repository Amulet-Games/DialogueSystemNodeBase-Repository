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
            StoryNodeData data = new();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveFirstContentBoxContainers();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void SaveFirstContentBoxContainers()
            {
                // Character SO.
                data.DialogueCharacter = Model.CharacterObjectContainer.Value;

                // Audio clip.
                Model.AudioClipContainer.SaveContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                Model.FirstTextlineTextContainer.SaveContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                data.SecondLineTriggerTypeEnumIndex = Model.SecondLineTriggerTypeEnumContainer.Value;

                // Duration float.
                data.DurationFloat = Model.DurationFloatContainer.Value;

                // Second textline text.
                Model.SecondTextlineTextContainer.SaveContainerValue(data.SecondTextlineTextLanguageGeneric);
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
        public override void LoadNode(StoryNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadFirstContentBoxContainers();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.OutputPort.name = data.OutputPortGUID;
            }

            void LoadFirstContentBoxContainers()
            {
                // Character SO.
                Model.CharacterObjectContainer.LoadContainerValue(data.DialogueCharacter);

                // Audio clip.
                Model.AudioClipContainer.LoadContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                Model.FirstTextlineTextContainer.LoadContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                Model.SecondLineTriggerTypeEnumContainer.LoadContainerValue(data.SecondLineTriggerTypeEnumIndex);

                // Duration float.
                Model.DurationFloatContainer.LoadContainerValue(data.DurationFloat);

                // Second textline text.
                Model.SecondTextlineTextContainer.LoadContainerValue(data.SecondTextlineTextLanguageGeneric);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                Model.CsvGUID = data.CsvGUID;
            }
        }
    }
}