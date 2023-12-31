namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortPresenter : PortPresenterFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultPortPresenter,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public override DefaultPortPresenter Setup(PortModel detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override DefaultPort Create() => new(Detail);
    }
}