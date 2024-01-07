namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortPresenter : PortPresenterFrameBase
    <
        DefaultPort,
        DefaultPortPresenter
    >
    {
        /// <inheritdoc />
        public override DefaultPort Create(PortModel model) => new(model);
    }
}