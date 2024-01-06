namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortCallback : PortCallbackFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultPortCallback,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultPortCallback Setup(DefaultPort port)
        {
            Port = port;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPostConnect(EdgeBase edge)
        {
            Port.PostConnectEvent?.Invoke(edge);
        }


        /// <inheritdoc />
        public override void OnPreDisconnect(EdgeBase edge)
        {
            Port.PreDisconnectEvent?.Invoke(edge);
        }
    }
}