namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortSerializer : PortSerializerFrameBase<PortData>
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(PortBase port, PortData data)
        {
            base.Save(port, data);

            SavePortBaseValues();
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PortBase port, PortData data)
        {
            base.Load(port, data);

            LoadPortBaseValues();
        }
    }
}