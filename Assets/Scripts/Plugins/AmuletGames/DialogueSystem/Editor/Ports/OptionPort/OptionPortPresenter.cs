namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortPresenter : PortPresenterFrameBase
    <
        OptionPort,
        OptionPortCreateDetail,
        OptionPortPresenter,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <inheritdoc />
        public override OptionPortPresenter Setup(OptionPortCreateDetail detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override OptionPort Create() => new(Detail);
    }
}