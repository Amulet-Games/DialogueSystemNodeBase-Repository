using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodePresenter : NodePresenterFrameBase
    <
        EndNode,
        EndNodeModel
    >
    {
        /// <inheritdoc />
        public override EndNode CreateElements(EndNodeModel model, GraphViewer graphViewer)
        {
            var node = new EndNode(model, graphViewer);

            CreateTitleElements(node, model);
            CreatePortElements(node, model);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreatePortElements(EndNode node, EndNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            node.Add(model.InputDefaultPort);
            node.RefreshPorts();
        }
    }
}