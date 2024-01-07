namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateDefaultConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        DefaultPort,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateDefaultConnectorWindow Setup
        (
            NodeCreateConnectorCallback<DefaultPort> callback,
            NodeCreateConnectorDetail<DefaultPort> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}