namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortSerializer : PortSerializerFrameBase
    <
        OptionPort,
        OptionPortData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionPort port, OptionPortData data)
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
        public override void Load(OptionPort port, OptionPortData data)
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