namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeModel : NodeModelFrameBase<OptionBranchNode>
    {
        /// <summary>
        /// Content button for adding conditions to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// Text field model for the branch title.
        /// </summary>
        public LanguageTextFieldModel BranchTitleTextFieldModel;


        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public OptionBranchNodeStitcher OptionBranchNodeStitcher;


        /// <summary>
        /// The input option port of the node.
        /// </summary>
        public OptionPort InputOptionPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public OptionBranchNodeModel(OptionBranchNode node)
        {
            Node = node;
            BranchTitleTextFieldModel = new(placeholderText: StringConfig.OptionBranchNode_BranchTitleTextField_PlaceholderText);
            OptionBranchNodeStitcher = new();
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputOptionPort);
            Node.GraphViewer.Remove(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputOptionPort.Disconnect(Node.GraphViewer);
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}
