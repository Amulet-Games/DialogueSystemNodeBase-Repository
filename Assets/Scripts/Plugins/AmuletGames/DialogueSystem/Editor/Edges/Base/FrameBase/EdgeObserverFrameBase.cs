namespace AG.DS
{
    public abstract class EdgeObserverFrameBase<TEdge>
        : EdgeObserverBase
        where TEdge : EdgeBase
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        protected TEdge Edge;


        /// <summary>
        /// Setup for the edge observer frame base class.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <returns>The after setup edge observer frame base class.</returns>
        public abstract EdgeObserverFrameBase<TEdge> Setup(TEdge edge);


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge.
        /// </summary>
        public abstract void RegisterEvents();
    }
}