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
        /// <inheritdoc />
        public override void Save(StoryNode node, StoryNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                model.SecondLineTriggerTypeEnumIndex = node.View.SecondLineTriggerTypeEnumContainer.Value;
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                model.CsvGUID = node.View.CsvGUID;
            }
        }


        /// <inheritdoc />
        public override void Load(StoryNode node, StoryNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                node.View.SecondLineTriggerTypeEnumContainer.Load(model.SecondLineTriggerTypeEnumIndex);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                node.View.CsvGUID = model.CsvGUID;
            }
        }
    }
}