namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortPresenter : PortPresenterFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView,
        OptionPortPresenter
    >
    {
        /// <inheritdoc />
        public override OptionPortPresenter Setup(PortCreateDetail detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override OptionPort Create() => new(Detail);
    }
}