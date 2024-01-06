namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortSerializer : PortSerializerFrameBase
    <
        DefaultPort,
        PortData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DefaultPort port, PortData data)
        {
            base.Save(port, data);

            SavePortBaseValues();
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(DefaultPort port, PortData data)
        {
            base.Load(port, data);

            LoadPortBaseValues();
        }
    }
}