namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdge : EdgeFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultEdge Setup
        (
            DefaultEdgeView view,
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
            AddToClassList(StyleConfig.DefaultEdge);
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle);
        }
    }
}