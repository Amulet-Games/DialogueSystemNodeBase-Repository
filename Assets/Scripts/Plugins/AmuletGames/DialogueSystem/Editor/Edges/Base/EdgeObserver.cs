namespace AG.DS
{
    /// <summary>
    /// Register events to the edge element.
    /// </summary>
    public class EdgeObserver
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        EdgeBase edge;


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void RegisterEvents(EdgeBase edge)
        {
            this.edge = edge;
        }
    }
}