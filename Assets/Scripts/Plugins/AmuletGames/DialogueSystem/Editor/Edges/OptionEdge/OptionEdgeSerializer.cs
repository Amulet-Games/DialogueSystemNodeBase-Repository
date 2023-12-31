namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        OptionPortCreateDetail,
        OptionEdge,
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
            Data.PortType = PortType.OPTION;
        }
    }
}