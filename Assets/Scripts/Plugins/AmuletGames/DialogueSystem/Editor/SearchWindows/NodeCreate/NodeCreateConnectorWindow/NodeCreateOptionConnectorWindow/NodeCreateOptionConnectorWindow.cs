namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback<OptionPort, OptionEdge, OptionEdgeView> callback,
            NodeCreateConnectorDetail<OptionPort, OptionEdge, OptionEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}