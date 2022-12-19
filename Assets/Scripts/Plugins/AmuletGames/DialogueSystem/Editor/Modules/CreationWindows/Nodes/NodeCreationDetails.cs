using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// A class that provides an additional details about creating nodes, like its aglinment and connector port.
    /// <br>Other module classes can freely edit or use the values within the class.</br>
    /// </summary>
    public class NodeCreationDetails
    {
        /// <summary>
        /// The type of alignment that the node should follow when it is created on the graph.
        /// </summary>
        public C_Alignment_HorizontalType HorizontalAlignType { get; private set; }


        /// <summary>
        /// The connector type of the port is representing when the node creation happened.
        /// </summary>
        public P_ConnectorType ConnectorType { get; private set; }


        /// <summary>
        /// The target port to connect after the node creation is done.
        /// <br>If node is created through nodeCreationRequest, simply leave the field as null.</br>
        /// </summary>
        public Port ConnectorPort { get; private set; }


        /// <summary>
        /// The vector2 position on the graph where this node'll be placed to once it's created.
        /// </summary>
        public Vector2 PlacePosition { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node creation details module class.
        /// </summary>
        public NodeCreationDetails() { }


        /// <summary>
        /// Constructor of the node creation details module class.
        /// </summary>
        /// <param name="horizontalAlignType">The horizontal alignment type to initalize as.</param>
        /// <param name="connectorPort">The connector port to initalize as.</param>
        public NodeCreationDetails
        (
            C_Alignment_HorizontalType horizontalAlignType,
            Port connectorPort
        )
        {
            HorizontalAlignType = horizontalAlignType;
            ConnectorType = P_ConnectorType.Default;
            ConnectorPort = connectorPort;
        }


        // ----------------------------- Update Properties Services -----------------------------
        /// <summary>
        /// Method for updating the internal properties for the first time.
        /// </summary>
        /// <param name="horizontalAlignType">The new horizontal alignment type values to set for.</param>
        /// <param name="creationConnectorType">The connector type to set for.</param>
        /// <param name="connectorPort">The new connector port values to set for.</param>
        public void PreUpdateValues
        (
            C_Alignment_HorizontalType horizontalAlignType,
            P_ConnectorType creationConnectorType,
            Port connectorPort
        )
        {
            HorizontalAlignType = horizontalAlignType;
            ConnectorType = creationConnectorType;
            ConnectorPort = connectorPort;
        }


        /// <summary>
        /// Method for updating the internal properties for the second time.
        /// </summary>
        /// <param name="placePosition">The new place position value to set for.</param>
        /// <param name="isLockedWidth">The type of node that the details is used to create.</param>
        public void PostUpdateValues(Vector2 placePosition)
        {
            PlacePosition = placePosition;
        }
    }
}