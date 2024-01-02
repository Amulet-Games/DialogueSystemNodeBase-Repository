namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionEdgeView,
        EdgeDataBase
    >
    {
        /// <inheritdoc />
        public override void Save(OptionEdgeView view, EdgeDataBase data)
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
            Data.Port = PortModel.Port.Option;
        }
    }
}