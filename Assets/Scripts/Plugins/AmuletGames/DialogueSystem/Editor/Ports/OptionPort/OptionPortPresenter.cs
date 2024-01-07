namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortPresenter : PortPresenterFrameBase
    <
        OptionPort,
        OptionPortPresenter
    >
    {
        /// <inheritdoc />
        public override OptionPort Create(PortModel model) => new(model);
    }
}