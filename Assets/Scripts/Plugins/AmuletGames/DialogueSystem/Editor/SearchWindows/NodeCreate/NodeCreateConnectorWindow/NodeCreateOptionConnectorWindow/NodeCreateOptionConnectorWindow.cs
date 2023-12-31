namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionEdge,
        OptionEdgeView,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback<OptionPort, OptionPortModel, OptionEdge, OptionEdgeView> callback,
            NodeCreateConnectorDetail<OptionPort, OptionPortModel, OptionEdge, OptionEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}