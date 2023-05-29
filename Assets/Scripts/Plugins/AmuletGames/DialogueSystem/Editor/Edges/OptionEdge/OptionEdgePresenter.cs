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
            OptionEdge edge;

            CreateEdge();

            SetupDetail();

            AddToStyleClass();

            ShowConnectedStyle();

            return edge;

            void CreateEdge()
            {
                edge = new OptionEdge();
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
                edge.AddToClassList(StyleConfig.Instance.Option_Edge);
            }

            void ShowConnectedStyle()
            {
                edge.ShowConnectStyle();
            }
        }
    }
}