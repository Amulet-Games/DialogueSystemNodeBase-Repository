namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdge : EdgeFrameBase
    <
        OptionPort,
        OptionPortCreateDetail,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionEdge Setup
        (
            OptionEdgeView view,
            IEdgeCallback callback
        )
        {
            base.Setup(view, callback);

            SetupDetails();

            SetupStyleClass();

            SetupStyleSheet();

            return this;
        }


        /// <summary>
        /// Setup the details
        /// </summary>
        void SetupDetails()
        {
            focusable = true;
        }


        /// <summary>
        /// Setup the style class.
        /// </summary>
        void SetupStyleClass()
        {
            AddToClassList(StyleConfig.OptionEdge);
        }


        void SetupStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSOptionEdgeStyle);
        }
    }
}