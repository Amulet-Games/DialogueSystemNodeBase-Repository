namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortCallbackFrameBase
    <
        TPort,
        TPortModel,
        TPortCallback
    >
        : PortCallbackBase, IPortCallback
        where TPort : PortFrameBase<TPort, TPortModel>
        where TPortModel : PortModel
        where TPortCallback : PortCallbackFrameBase<TPort, TPortModel, TPortCallback>
    {
        /// <summary>
        /// Reference of the port element.
        /// </summary>
        public TPort Port;


        /// <summary>
        /// Setup for the port callback frame base class.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        public abstract TPortCallback Setup(TPort port);


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the port is connected to another port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public abstract void OnPostConnect(EdgeBase edge);


        /// <summary>
        /// The event to invoke when the port is disconnected to another port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public abstract void OnPreDisconnect(EdgeBase edge);


        /// <summary>
        /// The event to invoke after the previous connecting edge has been dropped in a empty space.
        /// </summary>
        public abstract void OnPostConnectingEdgeDropOutside();
    }
}