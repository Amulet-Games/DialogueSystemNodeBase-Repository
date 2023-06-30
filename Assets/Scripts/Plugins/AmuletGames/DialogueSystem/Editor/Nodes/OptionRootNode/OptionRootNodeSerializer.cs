namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public OptionRootNodeSerializer(OptionRootNode node, OptionRootNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel)
        {
            OptionRootNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveHeaderTextContainer();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.OutputOptionPort.Save(model.OutputOptionPortModel);
                View.OutputOptionPortGroupView.Save(model: model.OutputOptionPortGroupModel);
            }

            void SaveHeaderTextContainer()
            {
                View.RootTitleTextFieldView.Save(model.HeadlineText);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionRootNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            LoadHeaderTextContainer();

            RefreshPortsLayout();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.OutputOptionPort.Load(model.OutputOptionPortModel);
                View.OutputOptionPortGroupView.Load(Node, model.OutputOptionPortGroupModel);
            }

            void LoadHeaderTextContainer()
            {
                View.RootTitleTextFieldView.Load(model.HeadlineText);
            }

            void RefreshPortsLayout()
            {
                Node.RefreshPorts();
            }
        }
    }
}