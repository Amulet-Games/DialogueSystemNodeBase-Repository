namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        EdgeDataBase
    >
    {
        /// <inheritdoc />
        public override void Save(Edge<OptionPort> edge, EdgeDataBase data)
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
            Data.Port = PortModel.Port.Option;
        }
    }
}