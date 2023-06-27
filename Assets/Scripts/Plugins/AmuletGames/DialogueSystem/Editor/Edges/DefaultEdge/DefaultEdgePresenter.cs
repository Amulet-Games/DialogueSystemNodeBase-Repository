namespace AG.DS
{
    public class DefaultEdgePresenter : EdgePresenterFrameBase
    <
        DefaultEdge,
        DefaultPort
    >
    {
        /// <inheritdoc />
        public override DefaultEdge CreateElement(DefaultPort output, DefaultPort input)
        {
            // Create edge
            var edge = new DefaultEdge();

            // Setup detail
            edge.Setup(output, input);
            edge.focusable = true;

            // Add style
            edge.AddToClassList(StyleConfig.Default_Edge);
            return edge;
        }
    }
}