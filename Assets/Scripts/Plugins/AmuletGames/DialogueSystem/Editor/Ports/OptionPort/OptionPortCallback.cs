namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortCallback : PortCallbackFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionPortCallback,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionPortCallback Setup(OptionPort port)
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


        /// <inheritdoc />
        public override void OnPostConnectingEdgeDropOutside()
        {
            Port.PostConnectingEdgeDropOutsideEvent?.Invoke();
        }
    }
}