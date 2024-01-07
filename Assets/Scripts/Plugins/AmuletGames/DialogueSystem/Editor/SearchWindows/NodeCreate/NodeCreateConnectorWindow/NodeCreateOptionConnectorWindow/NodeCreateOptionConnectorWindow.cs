namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateOptionConnectorWindow : NodeCreateConnectorWindowFrameBase
    <
        OptionPort,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override NodeCreateOptionConnectorWindow Setup
        (
            NodeCreateConnectorCallback<OptionPort> callback,
            NodeCreateConnectorDetail<OptionPort> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }
    }
}