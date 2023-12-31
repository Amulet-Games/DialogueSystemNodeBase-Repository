namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdge : EdgeFrameBase
    <
        OptionPort,
        OptionPortModel,
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

            AddStyleClass();

            AddStyleSheet();

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
        /// Add the style class.
        /// </summary>
        void AddStyleClass()
        {
            AddToClassList(StyleConfig.OptionEdge);
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle);
        }
    }
}