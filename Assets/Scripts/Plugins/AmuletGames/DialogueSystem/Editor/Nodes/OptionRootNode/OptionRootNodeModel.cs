using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeModel : NodeModelFrameBase<OptionRootNode>
    {
        /// <summary>
        /// Text field model for the option root title.
        /// </summary>
        public LanguageTextFieldModel OptionRootTitleTextFieldModel;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output option port of the node.
        /// </summary>
        public OptionPort OutputOptionPort;


        /// <summary>
        /// The output option port group model of the node.
        /// </summary>
        public OptionPortGroupModel OutputOptionPortGroupModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public OptionRootNodeModel(OptionRootNode node)
        {
            Node = node;

            OptionRootTitleTextFieldModel = new(
                placeholderText: StringConfig.Instance.OptionRootGroup_FieldPlaceholderText);
            
            OutputOptionPortGroupModel = new(direction: Direction.Output);
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;

            serializeHandler.RemoveCachePort(port: InputDefaultPort);
            serializeHandler.RemoveCachePort(port: OutputOptionPort);

            for (int i = 0; i < OutputOptionPortGroupModel.Cells.Count; i++)
                serializeHandler.RemoveCachePort(port: OutputOptionPortGroupModel.Cells[i].Port);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            OutputOptionPort.Disconnect(Node.GraphViewer);
            OutputOptionPortGroupModel.Disconnect(Node.GraphViewer);
        }
    }
}
