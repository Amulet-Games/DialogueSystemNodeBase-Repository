namespace AG.DS
{
    public abstract class EdgeCallbackFrameBase<TEdge>
        : EdgeCallbackBase
        where TEdge : EdgeBase
    {
        /// <summary>
        /// Reference of the edge element.
        /// </summary>
        protected TEdge Edge;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        /// <param name="edge">The type edge element to set for.</param>
        public abstract void Setup(TEdge edge);


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the edge.
        /// </summary>
        public abstract void RegisterEvents();
    }
}