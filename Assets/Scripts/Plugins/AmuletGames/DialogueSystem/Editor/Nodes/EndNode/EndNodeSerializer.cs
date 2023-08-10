namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeSerializer : NodeSerializerFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeCallback,
        EndNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(EndNode node, EndNodeModel model)
        {
            base.Save(node, model);

            // Save ports
            node.View.InputDefaultPort.Save(model.InputPortModel);
        }


        /// <inheritdoc />
        public override void Load(EndNode node, EndNodeModel model)
        {
            base.Load(node, model);

            // Load ports
            node.View.InputDefaultPort.Load(model.InputPortModel);
        }
    }
}