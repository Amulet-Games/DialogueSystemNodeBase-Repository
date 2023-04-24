namespace AG.DS
{
    public abstract class EdgeCallbackFrameBase<TEdge>
        : EdgeCallbackBase
        where TEdge : EdgeBase
    {
        /// <summary>
        /// Reference of the edge module.
        /// </summary>
        protected TEdge Edge;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        /// <param name="edge">The edge base module to set for.</param>
        public abstract void Setup(TEdge edge);


        // ----------------------------- Register Events Service -----------------------------
        /// <summary>
        /// Register events to the edge.
        /// </summary>
        public abstract void RegisterEvents();
    }
}