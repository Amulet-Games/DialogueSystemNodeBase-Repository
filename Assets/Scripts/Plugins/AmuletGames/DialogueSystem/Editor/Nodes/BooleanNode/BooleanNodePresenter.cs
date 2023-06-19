using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        /// <inheritdoc />
        public override BooleanNode CreateElements(BooleanNodeModel model, GraphViewer graphViewer)
        {
            var node = new BooleanNode(model, graphViewer);

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
        void CreatePortElements(BooleanNode node, BooleanNodeModel model)
        {
            model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            model.TrueOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_True_LabelText
            );

            model.FalseOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_False_LabelText,
                isSiblings: true
            );

            node.Add(model.InputDefaultPort);
            node.Add(model.TrueOutputDefaultPort);
            node.Add(model.FalseOutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        void CreateContentElements(BooleanNode node, BooleanNodeModel model)
        {
            // Create all the root elements required in the node stitcher.
            model.booleanNodeStitcher.CreateRootElements(node);
        }
    }
}