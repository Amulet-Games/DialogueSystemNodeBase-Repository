namespace AG.DS
{
    /// <summary>
    /// Holds the methods for saving and loading the port view's value.
    /// </summary>
    public class PortSerializer
    {
        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public static void Save(Port port, PortData data)
        {
            data.Guid = port.Guid;
        }


        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public static void Load(Port port, PortData data)
        {
            port.Guid = data.Guid;
        }
    }
}