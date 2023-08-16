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
        /// <inheritdoc />
        public override void Save(OptionBranchNode node, OptionBranchNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveBranchTitleTextField();

            SaveOptionBranchNodeStitcher();

            void SavePorts()
            {
                node.View.OutputDefaultPort.Save(model.OutputPortModel);
                node.View.InputOptionPort.Save(model.InputOptionPortModel);
            }

            void SaveBranchTitleTextField()
            {
                node.View.BranchTitleTextFieldView.Save(model.HeadlineText);
            }

            void SaveOptionBranchNodeStitcher()
            {
                node.View.OptionBranchNodeStitcher.SaveStitcherValues(model.OptionBranchNodeStitcherModel);
            }
        }


        /// <inheritdoc />
        public override void Load(OptionBranchNode node, OptionBranchNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadBranchTitleTextField();

            LoadOptionBranchNodeStitcher();

            void LoadPorts()
            {
                node.View.OutputDefaultPort.Load(model.OutputPortModel);
                node.View.InputOptionPort.Load(model.InputOptionPortModel);
            }

            void LoadBranchTitleTextField()
            {
                node.View.BranchTitleTextFieldView.Load(model.HeadlineText);
            }

            void LoadOptionBranchNodeStitcher()
            {
                node.View.OptionBranchNodeStitcher.LoadStitcherValues(model.OptionBranchNodeStitcherModel);
            }
        }
    }
}