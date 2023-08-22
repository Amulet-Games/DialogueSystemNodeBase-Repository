namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortSerializer : PortSerializerFrameBase
    <
        OptionPort,
        OptionPortModel
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(OptionPort port, OptionPortModel model)
        {
            base.Save(port, model);

            SavePortBaseValues();

            SavePortName();
        }


        /// <summary>
        /// Save the port name value.
        /// </summary>
        void SavePortName()
        {
            Model.PortName = Port.portName;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(OptionPort port, OptionPortModel model)
        {
            base.Load(port, model);

            LoadPortBaseValues();

            LoadPortName();
        }


        /// <summary>
        /// Load the port name value.
        /// </summary>
        void LoadPortName()
        {
            Port.portName = Model.PortName;
        }
    }
}