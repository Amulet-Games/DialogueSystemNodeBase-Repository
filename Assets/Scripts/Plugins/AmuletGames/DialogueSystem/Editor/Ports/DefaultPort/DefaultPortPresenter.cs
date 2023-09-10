namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortPresenter : PortPresenterFrameBase
    <
        DefaultPort,
        PortCreateDetailBase,
        DefaultPortPresenter,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultPortPresenter Setup(PortCreateDetailBase detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override DefaultPort Create() => new(Detail);
    }
}
//