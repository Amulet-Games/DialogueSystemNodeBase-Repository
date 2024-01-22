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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(StoryNode node, StoryNodeData data)
        {
            base.Save(node, data);

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
            //Data.InputPortData = PortManager.Instance.Save(View.InputPort);
            //Data.OutputPortData = PortManager.Instance.Save(View.OutputPort);
        }


        /// <summary>
        /// Save the second content box containers.
        /// </summary>
        void SaveSecondContentBoxContainers()
        {
            Data.SecondLineTriggerTypeEnumIndex = View.SecondLineTriggerTypeEnumContainer.Value;
        }


        /// <summary>
        /// Save the csv guid.
        /// </summary>
        void Save_CSV_GUID()
        {
            Data.CsvGUID = View.CsvGUID;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(StoryNode node, StoryNodeData data)
        {
            base.Load(node, data);

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
            //PortManager.Instance.Load(View.InputPort, Data.InputPortData);
            //PortManager.Instance.Load(View.OutputPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the second content box containers.
        /// </summary>
        void LoadSecondContentBoxContainers()
        {
            View.SecondLineTriggerTypeEnumContainer.Load(Data.SecondLineTriggerTypeEnumIndex);
        }


        /// <summary>
        /// Load the csv guid.
        /// </summary>
        void Load_CSV_Guid()
        {
            View.CsvGUID = Data.CsvGUID;
        }
    }
}