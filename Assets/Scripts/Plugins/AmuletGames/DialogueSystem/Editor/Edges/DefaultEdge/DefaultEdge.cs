namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdge : EdgeFrameBase
    <
        DefaultPort,
        PortCreateDetailBase,
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

            SetupStyleClass();

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
            AddToClassList(StyleConfig.Default_Edge);
        }
    }
}