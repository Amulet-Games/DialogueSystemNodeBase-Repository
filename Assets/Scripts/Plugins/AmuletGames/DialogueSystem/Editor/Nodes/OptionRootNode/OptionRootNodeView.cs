using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeView : NodeViewFrameBase
    {
        /// <summary>
        /// Content button for adding output option port to the node.
        /// </summary>
        public ContentButton ContentButton;


        /// <summary>
        /// Text field view for the root title.
        /// </summary>
        public LanguageTextFieldView RootTitleTextFieldView;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output option port of the node.
        /// </summary>
        public OptionPort OutputOptionPort;


        /// <summary>
        /// The output option port group view of the node.
        /// </summary>
        public OptionPortGroupView OutputOptionPortGroupView;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node view class.
        /// </summary>
        public OptionRootNodeView()
        {
            RootTitleTextFieldView = new(placeholderText: StringConfig.OptionRootNode_RootTitleTextField_PlaceholderText);
            OutputOptionPortGroupView = new(direction: Direction.Output);
        }


        // ----------------------------- Remove Ports -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputOptionPort);

            for (int i = 0; i < OutputOptionPortGroupView.Cells.Count; i++)
            {
                graphViewer.Remove(port: OutputOptionPortGroupView.Cells[i].Port);
            }

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputOptionPort.Disconnect(graphViewer);
            OutputOptionPortGroupView.Disconnect(graphViewer);
        }
    }
}
