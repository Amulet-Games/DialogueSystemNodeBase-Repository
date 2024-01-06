namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeSerializer : EdgeSerializerFrameBase
    <
        DefaultPort,
        PortModel,
        EdgeDataBase
    >
    {
        /// <inheritdoc />
        public override void Save(Edge<DefaultPort, PortModel> edge, EdgeDataBase data)
        {
            base.Save(edge, data);

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