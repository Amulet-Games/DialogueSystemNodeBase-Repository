namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView,
        EdgeModelBase
    >
    {
        /// <inheritdoc />
        public override void Save(OptionEdge edge, EdgeModelBase model)
        {
            base.Save(edge, model);

            model.PortType = PortType.OPTION;
        }
    }
}