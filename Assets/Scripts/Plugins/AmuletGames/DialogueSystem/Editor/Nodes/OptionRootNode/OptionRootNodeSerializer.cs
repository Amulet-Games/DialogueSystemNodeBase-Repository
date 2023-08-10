namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeCallback,
        OptionRootNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(OptionRootNode node, OptionRootNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveRootTitleTextField();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.OutputOptionPort.Save(model.OutputOptionPortModel);
                node.View.OutputOptionPortGroupView.Save(model.OutputOptionPortGroupModel);
            }

            void SaveRootTitleTextField()
            {
                node.View.RootTitleTextFieldView.Save(model.HeadlineText);
            }
        }


        /// <inheritdoc />
        public override void Load(OptionRootNode node, OptionRootNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadRootTitleTextField();

            RefreshPortsLayout();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.OutputOptionPort.Load(model.OutputOptionPortModel);
                node.View.OutputOptionPortGroupView.Load(node, model.OutputOptionPortGroupModel);
            }

            void LoadRootTitleTextField()
            {
                node.View.RootTitleTextFieldView.Load(model.HeadlineText);
            }

            void RefreshPortsLayout()
            {
                node.RefreshPorts();
            }
        }
    }
}