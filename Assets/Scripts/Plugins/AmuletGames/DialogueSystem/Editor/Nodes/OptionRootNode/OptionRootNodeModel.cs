using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// Content button for adding output option port to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// Text field model for the root title.
        /// </summary>
        public LanguageTextFieldModel RootTitleTextFieldModel;


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
        /// Constructor of the option root node model class.
        /// </summary>
        public OptionRootNodeModel()
        {
            RootTitleTextFieldModel = new(placeholderText: StringConfig.OptionRootNode_RootTitleTextField_PlaceholderText);
            OutputOptionPortGroupModel = new(direction: Direction.Output);
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputOptionPort);

            for (int i = 0; i < OutputOptionPortGroupModel.Cells.Count; i++)
            {
                graphViewer.Remove(port: OutputOptionPortGroupModel.Cells[i].Port);
            }

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputOptionPort.Disconnect(graphViewer);
            OutputOptionPortGroupModel.Disconnect(graphViewer);
        }
    }
}
