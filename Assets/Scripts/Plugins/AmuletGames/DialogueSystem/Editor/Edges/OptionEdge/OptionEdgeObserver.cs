namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeObserver : EdgeObserverFrameBase<Edge<OptionPort, OptionPortModel, OptionEdgeView>>
    {
        /// <summary>
        /// Reference of the option edge view.
        /// </summary>
        OptionEdgeView view;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<OptionPort, OptionPortModel, OptionEdgeView> edge)
        {
            Edge = edge;
            view = edge.View;
        }
    }
}