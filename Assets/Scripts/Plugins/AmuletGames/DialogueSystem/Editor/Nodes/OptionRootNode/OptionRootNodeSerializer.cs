namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel,
        OptionRootNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node serializer module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public OptionRootNodeSerializer(OptionRootNode node, OptionRootNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            OptionRootNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveHeaderTextContainer();

            AddData();

            void SavePorts()
            {
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.OutputOptionPort.Save(data.OutputOptionPortData);
                Model.OutputOptionPortGroupModel.Save(data: data.OutputOptionPortGroupData);
            }

            void SaveHeaderTextContainer()
            {
                Model.OptionRootTitleTextFieldModel.Save(data.HeadlineText);
            }

            void AddData()
            {
                dsData.OptionRootNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionRootNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadHeaderTextContainer();

            RefreshPortsLayout();

            void LoadPorts()
            {
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.OutputOptionPort.Load(data.OutputOptionPortData);
                Model.OutputOptionPortGroupModel.Load(Node, data.OutputOptionPortGroupData);
            }

            void LoadHeaderTextContainer()
            {
                Model.OptionRootTitleTextFieldModel.Load(data.HeadlineText);
            }

            void RefreshPortsLayout()
            {
                Node.RefreshPorts();
            }
        }
    }
}