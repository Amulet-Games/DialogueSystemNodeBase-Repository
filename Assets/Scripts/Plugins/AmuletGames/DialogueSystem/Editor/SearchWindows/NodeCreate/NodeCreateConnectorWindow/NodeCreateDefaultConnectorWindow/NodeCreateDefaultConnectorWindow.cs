namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateDefaultConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateDefaultConnectorWindow Setup
        (
            NodeCreateConnectorCallback<DefaultPort, PortModel, DefaultEdge, DefaultEdgeView> callback,
            NodeCreateConnectorDetail<DefaultPort, PortModel, DefaultEdge, DefaultEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}