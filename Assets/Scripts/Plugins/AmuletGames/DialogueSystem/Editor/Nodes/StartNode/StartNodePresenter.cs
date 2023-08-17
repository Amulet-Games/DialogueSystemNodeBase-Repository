using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodePresenter : NodePresenterFrameBase
    <
        StartNode,
        StartNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(StartNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();
        }


        /// <summary>
        /// Create the node's port elements.
        /// </summary>
        void CreatePortElements()
        {
            View.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(View.OutputDefaultPort);
            Node.RefreshPorts();
        }
    }
}