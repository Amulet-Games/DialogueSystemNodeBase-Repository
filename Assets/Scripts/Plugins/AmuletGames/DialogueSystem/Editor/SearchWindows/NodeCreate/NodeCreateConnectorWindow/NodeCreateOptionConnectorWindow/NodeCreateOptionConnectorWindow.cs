namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        OptionPort,
        OptionPortCreateDetail,
        OptionEdge,
        OptionEdgeView,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback<OptionPort, OptionPortCreateDetail, OptionEdge, OptionEdgeView> callback,
            NodeCreateConnectorDetail<OptionPort, OptionPortCreateDetail, OptionEdge, OptionEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}