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
            DefaultEdge edge;

            CreateEdge();

            SetupDetail();

            AddToStyleClass();

            return edge;

            void CreateEdge()
            {
                edge = new DefaultEdge();
            }

            void SetupDetail()
            {
                edge.Model = model;
                edge.output = model.Output;
                edge.input = model.Input;
                edge.focusable = true;
            }

            void AddToStyleClass()
            {
                edge.AddToClassList(StyleConfig.Instance.Default_Edge);
            }
        }
    }
}