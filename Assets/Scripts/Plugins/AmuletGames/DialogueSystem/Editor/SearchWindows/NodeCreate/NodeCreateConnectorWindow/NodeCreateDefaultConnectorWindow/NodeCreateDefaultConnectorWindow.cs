namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateDefaultConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        DefaultPort,
        PortCreateDetailBase,
        DefaultEdge,
        DefaultEdgeView,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateDefaultConnectorWindow Setup
        (
            NodeCreateConnectorCallback<DefaultPort, PortCreateDetailBase, DefaultEdge, DefaultEdgeView> callback,
            NodeCreateConnectorDetail<DefaultPort, PortCreateDetailBase, DefaultEdge, DefaultEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}