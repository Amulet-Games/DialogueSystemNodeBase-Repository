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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(StoryNode node, StoryNodeModel model)
        {
            base.Save(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Model.InputPortModel = PortManager.Instance.Save<DefaultPort, PortModelBase>(View.InputDefaultPort);
            Model.OutputPortModel = PortManager.Instance.Save<DefaultPort, PortModelBase>(View.OutputDefaultPort);
        }


        /// <summary>
        /// Save the second content box containers.
        /// </summary>
        void SaveSecondContentBoxContainers()
        {
            Model.SecondLineTriggerTypeEnumIndex = View.SecondLineTriggerTypeEnumContainer.Value;
        }


        /// <summary>
        /// Save the csv guid.
        /// </summary>
        void Save_CSV_GUID()
        {
            Model.CsvGUID = View.CsvGUID;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StoryNode node, StoryNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.OutputDefaultPort.Load(Model.OutputPortModel);
        }


        /// <summary>
        /// Load the second content box containers.
        /// </summary>
        void LoadSecondContentBoxContainers()
        {
            View.SecondLineTriggerTypeEnumContainer.Load(Model.SecondLineTriggerTypeEnumIndex);
        }


        /// <summary>
        /// Load the csv guid.
        /// </summary>
        void Load_CSV_Guid()
        {
            View.CsvGUID = Model.CsvGUID;
        }
    }
}