namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeObserver : EdgeObserverFrameBase<Edge<DefaultPort, PortModel>>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<DefaultPort, PortModel> edge)
        {
            Edge = edge;
        }
    }
}