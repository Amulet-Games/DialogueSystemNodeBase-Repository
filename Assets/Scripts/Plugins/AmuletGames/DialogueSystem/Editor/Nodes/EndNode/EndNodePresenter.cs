using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodePresenter : NodePresenterFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeCallback
    >
    {
        /// <inheritdoc />
        public override EndNode CreateElements
        (
            EndNodeView view,
            EndNodeCallback callback,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new EndNode(view, callback, graphViewer);

            CreateTitleElements(node, view);
            CreatePortElements(node, view);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreatePortElements(EndNode node, EndNodeView view)
        {
            view.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            node.Add(view.InputDefaultPort);
            node.RefreshPorts();
        }
    }
}