using UnityEditor.Experimental.GraphView;

namespace AG
{
    /// <summary>
    /// A class that provides an additional details about creating nodes, like its aglinment and connector port.
    /// <br>Other module classes can freely edit or use the values within the class.</br>
    /// </summary>
    public class DSNodeCreationDetails
    {
        /// <summary>
        /// The type of alignment that the node should follow when it is created on the graph.
        /// </summary>
        public C_Alignment_HorizontalType HorizontalAlignType { get; private set; }


        /// <summary>
        /// The connector type of the port is representing when the node creation happened.
        /// </summary>
        public N_NodeCreationConnectorType CreationConnectorType { get; private set; }


        /// <summary>
        /// The target port to connect after the node creation is done.
        /// <br>If node is created through nodeCreationRequest, simply leave the field as null.</br>
        /// </summary>
        public Port ConnectorPort { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system's node creation details.
        /// </summary>
        public DSNodeCreationDetails() { }


        /// <summary>
        /// Constructor of dialogue system's node creation details.
        /// </summary>
        /// <param name="horizontalAlignType">The horizontal alignment type to initalize as.</param>
        /// <param name="connectorPort">The connector port to initalize as.</param>
        public DSNodeCreationDetails
        (
            C_Alignment_HorizontalType horizontalAlignType,
            Port connectorPort
        )
        {
            HorizontalAlignType = horizontalAlignType;
            CreationConnectorType = N_NodeCreationConnectorType.Default;
            ConnectorPort = connectorPort;
        }


        // ----------------------------- Update Properties Services -----------------------------
        /// <summary>
        /// Method for updating the template internal properties.
        /// </summary>
        /// <param name="horizontalAlignType">The new horizontal alignment type values to set for.</param>
        /// <param name="creationConnectorType">The connector type to set for.</param>
        /// <param name="connectorPort">The new connector port values to set for.</param>
        public void UpdateValues
        (
            C_Alignment_HorizontalType horizontalAlignType,
            N_NodeCreationConnectorType creationConnectorType,
            Port connectorPort
        )
        {
            HorizontalAlignType = horizontalAlignType;
            CreationConnectorType = creationConnectorType;
            ConnectorPort = connectorPort;
        }
    }
}