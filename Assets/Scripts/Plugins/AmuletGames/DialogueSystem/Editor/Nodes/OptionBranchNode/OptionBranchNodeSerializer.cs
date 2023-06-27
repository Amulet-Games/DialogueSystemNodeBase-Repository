namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeSerializer : NodeSerializerFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public OptionBranchNodeSerializer(OptionBranchNode node, OptionBranchNodeView view)
        {
            Node = node;
            View = view;
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
                View.OutputDefaultPort.Save(data.OutputPortData);
                View.InputOptionPort.Save(data.InputOptionPortData);
            }

            void SaveHeaderTextContainer()
            {
                View.BranchTitleTextFieldView.Save(data.HeadlineText);
            }

            void SaveOptionBranchNodeStitcher()
            {
                View.OptionBranchNodeStitcher.SaveStitcherValues(data.OptionBranchNodeStitcherData);
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
                View.OutputDefaultPort.Load(data.OutputPortData);
                View.InputOptionPort.Load(data.InputOptionPortData);
            }

            void LoadHeaderTextContainer()
            {
                View.BranchTitleTextFieldView.Load(data.HeadlineText);
            }

            void LoadOptionBranchNodeStitcher()
            {
                View.OptionBranchNodeStitcher.LoadStitcherValues(data.OptionBranchNodeStitcherData);
            }
        }
    }
}