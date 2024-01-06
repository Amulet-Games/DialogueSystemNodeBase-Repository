namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        OptionPortModel,
        EdgeDataBase
    >
    {
        /// <inheritdoc />
        public override void Save(Edge<OptionPort, OptionPortModel> edge, EdgeDataBase data)
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