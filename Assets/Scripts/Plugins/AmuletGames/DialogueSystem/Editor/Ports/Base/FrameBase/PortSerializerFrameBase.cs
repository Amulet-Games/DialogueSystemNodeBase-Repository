namespace AG.DS
{
    /// <inheritdoc />
    public class PortSerializerFrameBase
    <
        TPort,
        TPortModel
    >
        : PortSerializerBase
        where TPort : PortBase
        where TPortModel : PortModelBase
    {
        /// <summary>
        /// Reference of the port element.
        /// </summary>
        protected TPort Port;


        /// <summary>
        /// Reference of the port model.
        /// </summary>
        protected TPortModel Model;


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="model">The port model to set for.</param>
        public virtual void Save(TPort port, TPortModel model)
        {
            Port = port;
            Model = model;
        }


        /// <summary>
        /// Save the port base values.
        /// </summary>
        protected void SavePortBaseValues()
        {
            Model.Guid = Port.Guid;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="model">The port model to set for.</param>
        public virtual void Load(TPort port, TPortModel model)
        {
            Port = port;
            Model = model;
        }


        /// <summary>
        /// Load the port base values.
        /// </summary>
        protected void LoadPortBaseValues()
        {
            Port.Guid = Model.Guid;
        }
    }
}