namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeSerializer : EdgeSerializerFrameBase
    <
        DefaultPort,
        DefaultEdge,
        DefaultEdgeView,
        EdgeModelBase
    >
    {
        /// <inheritdoc />
        public override void Save(DefaultEdge edge, EdgeModelBase model)
        {
            base.Save(edge, model);

            model.PortType = PortType.DEFAULT;
        }
    }
}