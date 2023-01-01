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
            OptionWindowNodeData data = new();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveOutputSingleOptionChannel();

            SaveOutputMultiOptionChannelGroup();

            SaveHeaderTextContainer();

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

            void RefreshPortsLayout()
            {
                // Update ports layout.
                Node.RefreshPorts();
            }
        }
    }
}