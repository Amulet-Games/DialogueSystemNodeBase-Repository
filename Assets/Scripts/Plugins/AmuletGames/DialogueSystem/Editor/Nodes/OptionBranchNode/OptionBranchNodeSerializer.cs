namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeSerializer : NodeSerializerFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeModel
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
        public override void Save(DialogueSystemModel dsModel)
        {
            OptionBranchNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveHeaderTextContainer();

            SaveOptionBranchNodeStitcher();

            AddToDsModel();

            void SavePorts()
            {
                View.OutputDefaultPort.Save(model.OutputPortModel);
                View.InputOptionPort.Save(model.InputOptionPortModel);
            }

            void SaveHeaderTextContainer()
            {
                View.BranchTitleTextFieldView.Save(model.HeadlineText);
            }

            void SaveOptionBranchNodeStitcher()
            {
                View.OptionBranchNodeStitcher.SaveStitcherValues(model.OptionBranchNodeStitcherModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionBranchNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            LoadHeaderTextContainer();

            LoadOptionBranchNodeStitcher();

            void LoadPorts()
            {
                View.OutputDefaultPort.Load(model.OutputPortModel);
                View.InputOptionPort.Load(model.InputOptionPortModel);
            }

            void LoadHeaderTextContainer()
            {
                View.BranchTitleTextFieldView.Load(model.HeadlineText);
            }

            void LoadOptionBranchNodeStitcher()
            {
                View.OptionBranchNodeStitcher.LoadStitcherValues(model.OptionBranchNodeStitcherModel);
            }
        }
    }
}