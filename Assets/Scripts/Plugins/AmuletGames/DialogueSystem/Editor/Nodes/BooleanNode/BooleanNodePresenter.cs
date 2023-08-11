using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeCallback
    >
    {
        /// <inheritdoc />
        public override BooleanNode CreateElements
        (
            BooleanNodeView view,
            BooleanNodeCallback callback,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            var node = new BooleanNode(view, callback, graphViewer);

            CreateTitleElements(node, view);
            CreatePortElements(node, view);
            CreateContentElements(node, view);

            return node;
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreatePortElements(BooleanNode node, BooleanNodeView view)
        {
            view.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            view.TrueOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_True_LabelText
            );

            view.FalseOutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_False_LabelText,
                isSiblings: true
            );

            node.Add(view.InputDefaultPort);
            node.Add(view.TrueOutputDefaultPort);
            node.Add(view.FalseOutputDefaultPort);
            node.RefreshPorts();
        }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        void CreateContentElements(BooleanNode node, BooleanNodeView view)
        {
            // Create all the root elements required in the node stitcher.
            view.booleanNodeStitcher.CreateRootElements(node);
        }
    }
}