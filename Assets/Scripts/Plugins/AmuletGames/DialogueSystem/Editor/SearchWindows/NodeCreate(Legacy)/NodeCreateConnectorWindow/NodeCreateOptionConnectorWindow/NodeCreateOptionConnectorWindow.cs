namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase<NodeCreateOptionConnectorWindow>
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback callback,
            NodeCreateConnectorDetail detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}