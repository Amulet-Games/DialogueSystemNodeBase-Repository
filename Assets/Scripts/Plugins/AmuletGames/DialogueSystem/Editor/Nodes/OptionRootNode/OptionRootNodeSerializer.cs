namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeSerializer : NodeSerializerFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeData
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
        public override void Save(DialogueSystemData dsData)
        {
            OptionRootNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveHeaderTextContainer();

            AddData();

            void SavePorts()
            {
                View.InputDefaultPort.Save(data.InputPortData);
                View.OutputOptionPort.Save(data.OutputOptionPortData);
                View.OutputOptionPortGroupView.Save(data: data.OutputOptionPortGroupData);
            }

            void SaveHeaderTextContainer()
            {
                View.RootTitleTextFieldView.Save(data.HeadlineText);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
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
                View.InputDefaultPort.Load(data.InputPortData);
                View.OutputOptionPort.Load(data.OutputOptionPortData);
                View.OutputOptionPortGroupView.Load(Node, data.OutputOptionPortGroupData);
            }

            void LoadHeaderTextContainer()
            {
                View.RootTitleTextFieldView.Load(data.HeadlineText);
            }

            void RefreshPortsLayout()
            {
                Node.RefreshPorts();
            }
        }
    }
}