namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortSerializer : PortSerializerFrameBase
    <
        DefaultPort,
        PortDataBase
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DefaultPort port, PortDataBase data)
        {
            base.Save(port, data);

            SavePortBaseValues();
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(DefaultPort port, PortDataBase data)
        {
            base.Load(port, data);

            LoadPortBaseValues();
        }
    }
}