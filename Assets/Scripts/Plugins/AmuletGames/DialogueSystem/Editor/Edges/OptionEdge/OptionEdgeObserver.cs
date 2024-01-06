namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeObserver : EdgeObserverFrameBase<Edge<OptionPort, OptionPortModel>>
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<OptionPort, OptionPortModel> edge)
        {
            Edge = edge;
        }
    }
}