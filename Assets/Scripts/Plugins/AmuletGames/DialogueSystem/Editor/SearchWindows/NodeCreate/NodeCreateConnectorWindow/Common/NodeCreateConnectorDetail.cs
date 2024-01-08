using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorDetail : NodeCreateDetailBase
    {
        /// <summary>
        /// The model's connector port.
        /// </summary>
        public PortBase ConnectorPort { get; private set; }


        /// <summary>
        /// The model's connector edge style sheet.</param>
        /// </summary>
        public StyleSheet ConnectorEdgeStyleSheet { get; private set; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the connector port.
        /// </summary>
        /// <param name="value">The new value to set for.</param>
        public void SetPortConnector(PortBase value) => ConnectorPort = value;


        /// <summary>
        /// Set a new value to the connector edge style sheet.
        /// </summary>
        /// <param name="value">The new value to set for.</param>
        public void SetEdgeStyleSheet(StyleSheet value) => ConnectorEdgeStyleSheet = value;
    }
}