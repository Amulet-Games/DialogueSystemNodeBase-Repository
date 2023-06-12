namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeModel : NodeModelFrameBase
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
        public OptionBranchNodeModel()
        {
            BranchTitleTextFieldModel = new(placeholderText: StringConfig.OptionBranchNode_BranchTitleTextField_PlaceholderText);
            OptionBranchNodeStitcher = new();
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputOptionPort);
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            InputOptionPort.Disconnect(graphViewer);
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}
