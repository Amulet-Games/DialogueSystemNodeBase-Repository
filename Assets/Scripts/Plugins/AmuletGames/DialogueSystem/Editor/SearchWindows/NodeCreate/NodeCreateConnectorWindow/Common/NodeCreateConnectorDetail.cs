namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorDetail
    <
        TPort,
        TPortCreateDetail
    >
        : NodeCreateDetailBase
        where TPort : PortFrameBase<TPort, TPortCreateDetail>
        where TPortCreateDetail : PortModel
    {
        /// <summary>
        /// Reference of the connector port.
        /// <br>If the node is created through the node create request window, the field's value will be null.</br>
        /// </summary>
        public TPort ConnectorPort { get; private set; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the connector port.
        /// </summary>
        /// <param name="value">The connector port to set for.</param>
        public void SetPortConnector(TPort value) => ConnectorPort = value;
    }
}