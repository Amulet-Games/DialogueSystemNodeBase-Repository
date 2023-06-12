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
        /// Constructor of the option branch node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
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
                Model.BranchTitleTextFieldModel.Save(data.HeadlineText);
            }

            void SaveOptionBranchNodeStitcher()
            {
                Model.OptionBranchNodeStitcher.SaveStitcherValues(data.OptionBranchNodeStitcherData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
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
                Model.BranchTitleTextFieldModel.Load(data.HeadlineText);
            }

            void LoadOptionBranchNodeStitcher()
            {
                Model.OptionBranchNodeStitcher.LoadStitcherValues(data.OptionBranchNodeStitcherData);
            }
        }
    }
}