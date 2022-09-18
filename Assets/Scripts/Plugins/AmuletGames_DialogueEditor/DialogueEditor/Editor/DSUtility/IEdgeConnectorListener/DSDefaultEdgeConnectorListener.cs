using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Listener that detects whenever an default edge was dragged and released within the custom editor graph.
    /// <para></para>
    /// <br>Used by EdgeConnector manipulator to finish the actual edge creation.</br>
    /// <br>Its an interface the user can override and create edges in a different way.</br>
    /// </summary>
    public class DSDefaultEdgeConnectorListener : IEdgeConnectorListener
    {
        /// <summary>
        /// Reference of the dialogue system's node creation connector window module.
        /// </summary>
        DSNodeCreationConnectorWindow nodeCreationConnectorWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system default edge connector listener.
        /// </summary>
        /// <param name="nodeCreationConnectorWindow">Dialogue system's node creation connector window module.</param>
        public DSDefaultEdgeConnectorListener(DSNodeCreationConnectorWindow nodeCreationConnectorWindow)
        {
            this.nodeCreationConnectorWindow = nodeCreationConnectorWindow;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Called when a new edge is dropped on a port.
        /// </summary>
        /// <param name="graphView">Reference to the GraphView.</param>
        /// <param name="edge">The edge being created.</param>
        public void OnDrop(GraphView graphView, Edge edge) { }


        /// <summary>
        /// Called when a new edge is dropped in empty space.
        /// </summary>
        /// <param name="edge">The edge being dropped.</param>
        /// <param name="position">The position in empty space the edge is dropped on.</param>
        public void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                nodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the left side.
                    C_Alignment_HorizontalType.Left,

                    // Default connector type.
                    N_NodeCreationConnectorType.Default,

                    // Connector port.
                    edge.input,

                    // Default node's input search entries.
                    DSNodeCreationEntriesProvider.DefaultNodeInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                nodeCreationConnectorWindow.UpdateWindowContext
                (
                    // Align on the right side.
                    C_Alignment_HorizontalType.Right,

                    // Default connector type.
                    N_NodeCreationConnectorType.Default,

                    // Connector port.
                    edge.output,

                    // Default node's output search entries.
                    DSNodeCreationEntriesProvider.DefaultNodeOutputEntries
                );
            }

            // Open window.
            nodeCreationConnectorWindow.Open(DSGraphView.GetCurrentEventMousePosition());
        }
    }
}