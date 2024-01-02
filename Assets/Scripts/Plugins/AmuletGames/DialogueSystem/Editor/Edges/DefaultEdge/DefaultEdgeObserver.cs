namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeObserver : EdgeObserverFrameBase<Edge<DefaultPort, PortModel, DefaultEdgeView>>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<DefaultPort, PortModel, DefaultEdgeView> edge)
        {
            Edge = edge;
        }
    }
}