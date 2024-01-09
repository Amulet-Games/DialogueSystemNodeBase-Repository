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
        public void Setup(PortBase port)
        {
            Port = port;
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
        /// The callback to invoke when the port is disconnected to another port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void OnPreDisconnect(EdgeBase edge)
        {
            Port.PreDisconnectEvent?.Invoke(edge);
        }


        /// <summary>
        /// The callback to invoke after the connecting edge has been dropped in an empty space.
        /// </summary>
        public void OnPostConnectingEdgeDropOutside()
        {
            Port.PostConnectingEdgeDropOutsideEvent?.Invoke();
        }
    }
}