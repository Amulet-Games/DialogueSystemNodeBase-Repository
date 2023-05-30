namespace AG.DS
{
    public class OptionEdgePresenter : EdgePresenterFrameBase
    <
        OptionEdge,
        OptionEdgeModel,
        OptionPort
    >
    {
        /// <inheritdoc />
        public override OptionEdge CreateElement(OptionEdgeModel model)
        {
            // Create edge
            var edge = new OptionEdge();

            // Setup detail
            edge.Model = model;
            edge.output = model.Output;
            edge.input = model.Input;
            edge.focusable = true;

            // Add style
            edge.AddToClassList(StyleConfig.Option_Edge);

            // Show connected style by default
            edge.ShowConnectStyle();
            return edge;
        }
    }
}