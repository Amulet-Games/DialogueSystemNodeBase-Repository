using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <summary>
    /// Dialogue system's default edge connector listener.
    /// </summary>
    public class DefaultEdgeConnectorListener : EdgeConnectorListenerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the default edge connector listener class.
        /// </summary>
        /// <param name="connectorWindow">Dialogue system's node creation connector window module.</param>
        public DefaultEdgeConnectorListener(NodeCreationConnectorWindow connectorWindow)
            : base(connectorWindow) { }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void EdgeConnectedAction(Edge edge)
        {
            DefaultEdgeCallbacks.Register(edge);
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the left side.
                    horizontalAlignType: C_Alignment_HorizontalType.Left,

                    // Default connector type.
                    creationConnectorType: P_ConnectorType.Default,

                    // Connector port.
                    connectorPort: edge.input,

                    // Default node's input search entries.
                    toShowSearchEntries: NodeCreationEntriesProvider.DefaultNodeInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    horizontalAlignType: C_Alignment_HorizontalType.Right,

                    // Default connector type.
                    creationConnectorType: P_ConnectorType.Default,

                    // Connector port.
                    connectorPort: edge.output,

                    // Default node's output search entries.
                    toShowSearchEntries: NodeCreationEntriesProvider.DefaultNodeOutputEntries
                );
            }

            // Open window.
            NodeCreationConnectorWindow.Open
            (
                screenPositionToShow: GraphViewer.GetCurrentEventMousePosition()
            );
        }
    }
}