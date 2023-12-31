namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeSerializer : EdgeSerializerFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView,
        EdgeDataBase
    >
    {
        /// <inheritdoc />
        public override void Save(DefaultEdgeView view, EdgeDataBase data)
        {
            base.Save(view, data);

            SaveEdgeBaseValues();

            SavePortType();
        }


        /// <summary>
        /// Save the port type.
        /// </summary>
        void SavePortType()
        {
            Data.Port = PortModel.Port.Default;
        }
    }
}