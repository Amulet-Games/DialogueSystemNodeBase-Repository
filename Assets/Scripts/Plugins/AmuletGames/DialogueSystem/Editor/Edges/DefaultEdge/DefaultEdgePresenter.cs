namespace AG.DS
{
    public class DefaultEdgePresenter : EdgePresenterFrameBase
    <
        DefaultEdge,
        DefaultEdgeModel,
        DefaultPort
    >
    {
        /// <inheritdoc />
        public override DefaultEdge CreateElement(DefaultEdgeModel model)
        {
            // Create edge
            var edge = new DefaultEdge();

            // Setup detail
            edge.Model = model;
            edge.output = model.Output;
            edge.input = model.Input;
            edge.focusable = true;

            // Add style
            edge.AddToClassList(StyleConfig.Default_Edge);
            return edge;
        }
    }
}