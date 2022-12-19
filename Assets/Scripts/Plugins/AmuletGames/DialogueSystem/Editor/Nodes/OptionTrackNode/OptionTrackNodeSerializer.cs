namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodeSerializer : NodeSerializerFrameBase
    <
        OptionTrackNode,
        OptionTrackNodeModel,
        OptionTrackNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public OptionTrackNodeSerializer(OptionTrackNode node, OptionTrackNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new OptionTrackNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveInputSingleOptionChannel();

            SaveHeaderTextContainer();

            SaveConditionSegment();

            AddData();

            void SavePortsGUID()
            {
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void SaveInputSingleOptionChannel()
            {
                Model.InputSingleOptionChannel.SaveChannelValues(data.InputSingleOptionChannelData);
            }

            void SaveHeaderTextContainer()
            {
                Model.HeaderTextContainer.SaveContainerValue(data.HeaderLanguageGeneric);
            }

            void SaveConditionSegment()
            {
                Model.ConditionSegment.SaveSegmentValues(data.ConditionSegmentData);
            }

            void AddData()
            {
                dsData.OptionTrackNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(OptionTrackNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadInputSingleOptionChannel();

            LoadHeaderTextContainer();

            LoadConditionSegment();

            void LoadPortsGUID()
            {
                Model.OutputPort.name = data.OutputPortGUID;
            }

            void LoadInputSingleOptionChannel()
            {
                Model.InputSingleOptionChannel.LoadChannelValues(data.InputSingleOptionChannelData);
            }

            void LoadHeaderTextContainer()
            {
                Model.HeaderTextContainer.LoadContainerValue(data.HeaderLanguageGeneric);
            }

            void LoadConditionSegment()
            {
                Model.ConditionSegment.LoadSegmentValues(data.ConditionSegmentData);
            }
        }
    }
}