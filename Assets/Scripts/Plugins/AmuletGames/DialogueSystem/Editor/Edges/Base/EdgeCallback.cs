namespace AG.DS
{
    /// <summary>
    /// Holds the methods that can be called when the edge changed its state.
    /// </summary>
    public class EdgeCallback : IEdgeCallback
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        EdgeBase edge;


        /// <summary>
        /// Setup for the edge callback class.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Setup(EdgeBase edge)
        {
            this.edge = edge;
        }


        // ----------------------------- Callback -----------------------------
        /// <summary>
        /// The callback to invoke when the edge is about to be removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Disconnect ports
            {
                edge.Input.Disconnect(edge);
                edge.Output.Disconnect(edge);
            }
        }


        /// <summary>
        /// The callback to invoke when the edge is removed from the graph by the user.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }
    }
}