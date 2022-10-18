using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system's default edge connector listener.
    /// </summary>
    public class DSDefaultEdgeConnectorListener : EdgeConnectorListenerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system default edge connector listener.
        /// </summary>
        /// <param name="nodeCreationConnectorWindow">Dialogue system's node creation connector window module.</param>
        public DSDefaultEdgeConnectorListener(DSNodeCreationConnectorWindow nodeCreationConnectorWindow)
            : base(nodeCreationConnectorWindow) { }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void EdgeConnectedAction(Edge edge)
        {
            DSDefaultEdgeCallbacks.Register(edge);
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
                    C_Alignment_HorizontalType.Left,

                    // Default connector type.
                    P_ConnectorType.Default,

                    // Connector port.
                    edge.input,

                    // Default node's input search entries.
                    DSNodeCreationEntriesProvider.DefaultNodeInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    C_Alignment_HorizontalType.Right,

                    // Default connector type.
                    P_ConnectorType.Default,

                    // Connector port.
                    edge.output,

                    // Default node's output search entries.
                    DSNodeCreationEntriesProvider.DefaultNodeOutputEntries
                );
            }

            // Open window.
            NodeCreationConnectorWindow.Open(DSGraphView.GetCurrentEventMousePosition());
        }
    }
}