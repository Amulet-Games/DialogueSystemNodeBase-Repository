namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeSerializer : NodeSerializerFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeModel
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
        public override void Save(DialogueSystemModel dsModel)
        {
            StoryNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                model.SecondLineTriggerTypeEnumIndex = View.SecondLineTriggerTypeEnumContainer.Value;
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                model.CsvGUID = View.CsvGUID;
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StoryNodeModel model)
        {
            base.Load();

            LoadPorts();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                View.SecondLineTriggerTypeEnumContainer.Load(model.SecondLineTriggerTypeEnumIndex);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                View.CsvGUID = model.CsvGUID;
            }
        }
    }
}