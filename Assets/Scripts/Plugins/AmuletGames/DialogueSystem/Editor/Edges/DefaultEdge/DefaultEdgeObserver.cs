namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeObserver : EdgeObserverFrameBase<DefaultEdge>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(DefaultEdge edge)
        {
            Edge = edge;
        }
    }
}