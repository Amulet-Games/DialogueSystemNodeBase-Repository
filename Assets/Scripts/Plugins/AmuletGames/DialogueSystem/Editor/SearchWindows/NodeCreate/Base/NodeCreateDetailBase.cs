namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new node.
    /// </summary>
    public class NodeCreateDetailBase
    {
        /// <summary>
        /// The horizontal alignment type to use when creating the node to the graph.
        /// </summary>
        public HorizontalAlignmentType HorizontalAlignmentType { get; private set; }


        /// <summary>
        /// The port type of the connector port.
        /// </summary>
        public ConnectorType ConnectorType { get; private set; }


        /// <summary>
        /// The port to connect to after the node is created.
        /// <br>If a node is created through the node create request window, the field's value will be null.</br>
        /// </summary>
        public PortBase ConnectorPort { get; private set; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the horizontal alignment type.
        /// </summary>
        /// <param name="value">The horizontal alignment type to set for.</param>
        public void SetTypeHorizontalAlignment(HorizontalAlignmentType value) => HorizontalAlignmentType = value;


        /// <summary>
        /// Set a new value to the connector type.
        /// </summary>
        /// <param name="value">The connector type to set for.</param>
        public void SetTypeConnector(ConnectorType value) => ConnectorType = value;


        /// <summary>
        /// Set a new value to the connector port.
        /// </summary>
        /// <param name="value">The connector port to set for.</param>
        public void SetPortConnector(PortBase value) => ConnectorPort = value;
    }
}