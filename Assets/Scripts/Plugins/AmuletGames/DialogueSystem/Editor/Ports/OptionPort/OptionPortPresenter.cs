namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortPresenter : PortPresenterFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionPortPresenter
    >
    {
        /// <inheritdoc />
        public override OptionPortPresenter Setup(OptionPortModel detail)
        {
            base.Setup(detail);
            return this;
        }


        /// <inheritdoc />
        public override OptionPort Create() => new(Model);
    }
}