namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeSerializer : EdgeSerializerFrameBase
    <
        OptionPort,
        OptionPortCreateDetail,
        OptionEdge,
        OptionEdgeView,
        EdgeModelBase
    >
    {
        /// <inheritdoc />
        public override void Save(OptionEdgeView view, EdgeModelBase model)
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
            Model.PortType = PortType.OPTION;
        }
    }
}