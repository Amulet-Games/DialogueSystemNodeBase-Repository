namespace AG.DS
{
    /// <inheritdoc />
    public class PortSerializerFrameBase<TPortData> : PortSerializerBase
        where TPortData : PortData
    {
        /// <summary>
        /// Reference of the port element.
        /// </summary>
        protected PortBase Port;


        /// <summary>
        /// Reference of the port data.
        /// </summary>
        protected TPortData Data;


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public virtual void Save(PortBase port, TPortData data)
        {
            Port = port;
            Data = data;
        }


        /// <summary>
        /// Save the port base values.
        /// </summary>
        protected void SavePortBaseValues()
        {
            Data.Guid = Port.Guid;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public virtual void Load(PortBase port, TPortData data)
        {
            Port = port;
            Data = data;
        }


        /// <summary>
        /// Load the port base values.
        /// </summary>
        protected void LoadPortBaseValues()
        {
            Port.Guid = Data.Guid;
        }
    }
}