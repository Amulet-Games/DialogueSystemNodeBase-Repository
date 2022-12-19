namespace AG.DS
{
    /// <inheritdoc />
    public class OptionWindowNodeSerializer : NodeSerializerFrameBase
    <
        OptionWindowNode,
        OptionWindowNodeModel,
        OptionWindowNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public OptionWindowNodeSerializer(OptionWindowNode node, OptionWindowNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new OptionWindowNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveOutputSingleOptionChannel();

            SaveOutputMultiOptionChannelGroup();

            SaveHeaderTextContainer();

            SaveDialogueSegment();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
            }

            void SaveOutputSingleOptionChannel()
            {
                Model.OutputSingleOptionChannel.SaveChannelValues
                (
                    data: data.OutputSingleOptionChannelData
                );
            }

            void SaveOutputMultiOptionChannelGroup()
            {
                Model.OutputMultiOptionChannelGroup.SaveGroupValues
                (
                    data: data.OutputMultiOptionChannelGroupData
                );
            }

            void SaveHeaderTextContainer()
            {
                Model.HeaderTextContainer.SaveContainerValue(data.HeaderLanguageGeneric);
            }

            void SaveDialogueSegment()
            {
                Model.DialogueSegment.SaveSegmentValues(data.DialogueSegmentData);
            }

            void AddData()
            {
                dsData.OptionWindowNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(OptionWindowNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadOutputSingleOptionChannel();

            LoadOutputMultiOptionChannelGroup();

            LoadHeaderTextContainer();

            LoadDialogueSegment();

            RefreshPortsLayout();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
            }

            void LoadOutputSingleOptionChannel()
            {
                Model.OutputSingleOptionChannel.LoadChannelValues(data.OutputSingleOptionChannelData);
            }

            void LoadOutputMultiOptionChannelGroup()
            {
                Model.OutputMultiOptionChannelGroup.LoadGroupValues(data.OutputMultiOptionChannelGroupData);
            }

            void LoadHeaderTextContainer()
            {
                Model.HeaderTextContainer.LoadContainerValue(data.HeaderLanguageGeneric);
            }

            void LoadDialogueSegment()
            {
                Model.DialogueSegment.LoadSegmentValues(data.DialogueSegmentData);
            }

            void RefreshPortsLayout()
            {
                // Update ports layout.
                Node.RefreshPorts();
            }
        }
    }
}