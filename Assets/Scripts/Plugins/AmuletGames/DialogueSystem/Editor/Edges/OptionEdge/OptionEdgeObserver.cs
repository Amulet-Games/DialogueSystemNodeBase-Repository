namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeObserver : EdgeObserverFrameBase<Edge<OptionPort>>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<OptionPort> edge)
        {
            Edge = edge;
        }
    }
}