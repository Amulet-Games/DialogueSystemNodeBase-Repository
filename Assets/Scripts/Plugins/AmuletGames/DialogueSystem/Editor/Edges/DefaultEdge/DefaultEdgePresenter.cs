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
        public override DefaultEdge CreateElements(DefaultEdgeModel model)
        {
            DefaultEdge edge;

            CreateEdge();

            SetupFrameFields();

            SetupDetail();

            AddToStyleClass();

            return edge;

            void CreateEdge()
            {
                edge = new DefaultEdge();
            }

            void SetupFrameFields()
            {
                edge.Model = model;
                edge.output = model.Output;
                edge.input = model.Input;
            }

            void SetupDetail()
            {
                edge.focusable = true;
            }

            void AddToStyleClass()
            {
                edge.AddToClassList(StyleConfig.Instance.Default_Edge);
            }
        }
    }
}