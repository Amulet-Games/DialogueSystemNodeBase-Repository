namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeSerializer : NodeSerializerFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(StartNode node, StartNodeModel model)
        {
            base.Load(node, model);

            // Save ports
            node.View.OutputDefaultPort.Save(model.OutputPortModel);
        }


        /// <inheritdoc />
        public override void Load(StartNode node, StartNodeModel model)
        {
            base.Load(node, model);

            // Load ports
            node.View.OutputDefaultPort.Load(model.OutputPortModel);
        }
    }
}