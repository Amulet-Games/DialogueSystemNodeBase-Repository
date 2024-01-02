namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionEdgeView,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback<OptionPort, OptionPortModel, OptionEdgeView> callback,
            NodeCreateConnectorDetail<OptionPort, OptionPortModel, OptionEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}