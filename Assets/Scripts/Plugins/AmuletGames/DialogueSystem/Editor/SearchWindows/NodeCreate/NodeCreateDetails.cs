using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// A class that provides an additional details about creating nodes, like its alignment and connector port.
    /// <br>Other classes can freely edit or use the values within the class.</br>
    /// </summary>
    public class NodeCreateDetails
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


        /// <summary>
        /// The vector2 position of the graph to create the node onto.
        /// </summary>
        public Vector2 CreatePosition { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node create details class.
        /// </summary>
        public NodeCreateDetails() { }


        /// <summary>
        /// Constructor of the node create details class.
        /// </summary>
        /// <param name="horizontalAlignType">The horizontal alignment type to set for.</param>
        /// <param name="connectorType">The connector type to set for.</param>
        /// <param name="connectorPort">The connector port to set for.</param>
        public NodeCreateDetails
        (
            HorizontalAlignmentType horizontalAlignType,
            ConnectorType connectorType = ConnectorType.NONE,
            PortBase connectorPort = null
        )
        {
            HorizontalAlignmentType = horizontalAlignType;
            ConnectorType = connectorType;
            ConnectorPort = connectorPort;
        }


        /// <summary>
        /// Set a new value to the horizontal alignment type.
        /// </summary>
        /// <param name="value">The horizontal alignment type to set for.</param>
        public void SetTypeHorizontalAligment(HorizontalAlignmentType value) => HorizontalAlignmentType = value;


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


        /// <summary>
        /// Set a new value to the create position.
        /// </summary>
        /// <param name="value">The position to set for.</param>
        public void SetPositionCreate(Vector2 value) => CreatePosition = value;
    }
}