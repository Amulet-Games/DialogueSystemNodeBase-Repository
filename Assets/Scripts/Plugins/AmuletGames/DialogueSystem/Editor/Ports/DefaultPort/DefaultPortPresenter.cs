namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortPresenter : PortPresenterFrameBase
    <
        DefaultPort,
        DefaultEdge,
        DefaultEdgeView,
        DefaultPortPresenter
    >
    {
        /// <inheritdoc />
        public override DefaultPortPresenter Setup(PortCreateDetail detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override DefaultPort Create() => new(Detail);
    }
}
//