namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateDefaultConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        DefaultPort,
        DefaultEdge,
        DefaultEdgeView,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateDefaultConnectorWindow Setup
        (
            NodeCreateConnectorCallback<DefaultPort, DefaultEdge, DefaultEdgeView> callback,
            NodeCreateConnectorDetail<DefaultPort, DefaultEdge, DefaultEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}