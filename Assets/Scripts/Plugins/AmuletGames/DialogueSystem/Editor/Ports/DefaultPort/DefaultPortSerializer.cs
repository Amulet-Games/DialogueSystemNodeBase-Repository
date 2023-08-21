namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortSerializer : PortSerializerFrameBase
    <
        DefaultPort,
        PortModelBase
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DefaultPort port, PortModelBase model)
        {
            base.Save(port, model);

            SavePortBaseValues();
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(DefaultPort port, PortModelBase model)
        {
            base.Load(port, model);

            LoadPortBaseValues();
        }
    }
}