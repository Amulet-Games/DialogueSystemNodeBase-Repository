namespace AG.DS
{
    public class OptionEdgePresenter : EdgePresenterFrameBase
    <
        OptionEdge,
        OptionPort
    >
    {
        /// <inheritdoc />
        public override OptionEdge CreateElement(OptionPort output, OptionPort input)
        {
            // Create edge
            var edge = new OptionEdge();

            // Setup detail
            edge.Setup(output, input);
            edge.focusable = true;

            // Add style
            edge.AddToClassList(StyleConfig.Option_Edge);

            // Show connected style by default
            edge.ShowConnectStyle();
            return edge;
        }
    }
}