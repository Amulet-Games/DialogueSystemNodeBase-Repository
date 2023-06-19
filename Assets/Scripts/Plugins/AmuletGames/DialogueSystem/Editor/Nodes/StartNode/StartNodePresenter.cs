using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodePresenter : NodePresenterFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        /// <inheritdoc />
        public override StartNode CreateElements(StartNodeModel model, GraphViewer graphViewer)
        {
            var node = new StartNode(model, graphViewer);

            CreateTitleElements(node, model);
            CreatePortElements(node, model);
            CreateContentElements(node, model);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreatePortElements(StartNode node, StartNodeModel model)
        {
            model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            node.Add(model.OutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(StartNode node, StartNodeModel model)
        {
        }
    }
}