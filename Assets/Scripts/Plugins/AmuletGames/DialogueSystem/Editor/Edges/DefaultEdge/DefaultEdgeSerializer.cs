namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeSerializer : EdgeSerializerFrameBase
    <
        DefaultPort,
        PortCreateDetailBase,
        DefaultEdge,
        DefaultEdgeView,
        EdgeModelBase
    >
    {
        /// <inheritdoc />
        public override void Save(DefaultEdgeView view, EdgeModelBase model)
        {
            base.Save(view, model);

            SaveEdgeBaseValues();

            SavePortType();
        }


        /// <summary>
        /// Save the port type.
        /// </summary>
        void SavePortType()
        {
            Model.PortType = PortType.DEFAULT;
        }
    }
}