namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdge : EdgeFrameBase
    <
        OptionPort,
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
            AddToClassList(StyleConfig.Option_Edge);
        }
    }
}