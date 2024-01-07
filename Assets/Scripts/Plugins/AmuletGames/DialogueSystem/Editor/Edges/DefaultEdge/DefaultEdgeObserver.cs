namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeObserver : EdgeObserverFrameBase<Edge<DefaultPort>>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<DefaultPort> edge)
        {
            Edge = edge;
        }
    }
}