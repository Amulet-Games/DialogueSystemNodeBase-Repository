namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateDefaultConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdgeView,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateDefaultConnectorWindow Setup
        (
            NodeCreateConnectorCallback<DefaultPort, PortModel, DefaultEdgeView> callback,
            NodeCreateConnectorDetail<DefaultPort, PortModel, DefaultEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}