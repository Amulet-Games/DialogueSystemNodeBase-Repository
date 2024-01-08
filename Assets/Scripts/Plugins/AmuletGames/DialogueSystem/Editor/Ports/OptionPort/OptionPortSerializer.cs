namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortSerializer : PortSerializerFrameBase<OptionPortData>
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(PortBase port, OptionPortData data)
        {
            base.Save(port, data);

            SavePortBaseValues();

            SavePortName();
        }


        /// <summary>
        /// Save the port name value.
        /// </summary>
        void SavePortName()
        {
            Data.PortName = Port.portName;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PortBase port, OptionPortData data)
        {
            base.Load(port, data);

            LoadPortBaseValues();

            LoadPortName();
        }


        /// <summary>
        /// Load the port name value.
        /// </summary>
        void LoadPortName()
        {
            Port.portName = Data.PortName;
        }
    }
}