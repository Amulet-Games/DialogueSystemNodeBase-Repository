namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeObserverFrameBase<TEdge>
        : EdgeObserverBase
        where TEdge : EdgeBase
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        protected TEdge Edge;


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public abstract void RegisterEvents(TEdge edge);
    }
}