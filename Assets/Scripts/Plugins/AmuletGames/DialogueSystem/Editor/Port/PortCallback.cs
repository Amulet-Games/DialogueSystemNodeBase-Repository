namespace AG.DS
{
    /// <summary>
    /// Holds the methods that can be called when the port changed its state.
    /// </summary>
    public class PortCallback : IPortCallback
    {
        /// <summary>
        /// Reference of the port element.
        /// </summary>
        public PortBase Port;


        /// <summary>
        /// Setup for the port callback frame base class.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        public PortCallback Setup(PortBase port)
        {
            Port = port;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the port is connected to another port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void OnPostConnect(EdgeBase edge)
        {
            Port.PostConnectEvent?.Invoke(edge);
        }


        /// <summary>
        /// The event to invoke when the port is disconnected to another port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void OnPreDisconnect(EdgeBase edge)
        {
            Port.PreDisconnectEvent?.Invoke(edge);
        }


        /// <summary>
        /// The event to invoke after the previous connecting edge has been dropped in a empty space.
        /// </summary>
        public void OnPostConnectingEdgeDropOutside()
        {
            Port.PostConnectingEdgeDropOutsideEvent?.Invoke();
        }
    }
}