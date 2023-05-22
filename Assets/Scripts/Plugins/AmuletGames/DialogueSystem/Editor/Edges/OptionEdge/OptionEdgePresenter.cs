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

            SetupFrameFields();

            SetupDetail();

            AddToStyleClass();

            ShowConnectedStyle();

            return edge;

            void CreateEdge()
            {
                edge = new OptionEdge();
                edge.output = model.Output;
                edge.input = model.Input;
            }

            void SetupFrameFields()
            {
                edge.Model = model;
            }

            void SetupDetail()
            {
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