namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeSerializer : NodeSerializerFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeModel,
        OptionBranchNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node serializer module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public OptionBranchNodeSerializer(OptionBranchNode node, OptionBranchNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            OptionBranchNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveHeaderTextContainer();

            SaveOptionBranchNodeStitcher();

            AddData();

            void SavePorts()
            {
                Model.OutputDefaultPort.Save(data.OutputPortData);
                Model.InputOptionPort.Save(data.InputOptionPortData);
            }

            void SaveHeaderTextContainer()
            {
                Model.OptionBranchTitleTextFieldModel.Save(data.HeadlineText);
            }

            void SaveOptionBranchNodeStitcher()
            {
                Model.OptionBranchNodeStitcher.SaveStitcherValues(data.OptionBranchNodeStitcherData);
            }

            void AddData()
            {
                dsData.OptionBranchNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionBranchNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadHeaderTextContainer();

            LoadOptionBranchNodeStitcher();

            void LoadPorts()
            {
                Model.OutputDefaultPort.Load(data.OutputPortData);
                Model.InputOptionPort.Load(data.InputOptionPortData);
            }

            void LoadHeaderTextContainer()
            {
                Model.OptionBranchTitleTextFieldModel.Load(data.HeadlineText);
            }

            void LoadOptionBranchNodeStitcher()
            {
                Model.OptionBranchNodeStitcher.LoadStitcherValues(data.OptionBranchNodeStitcherData);
            }
        }
    }
}