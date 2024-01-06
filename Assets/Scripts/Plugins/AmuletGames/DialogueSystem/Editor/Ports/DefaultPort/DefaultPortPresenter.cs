namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPortPresenter : PortPresenterFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultPortPresenter
    >
    {
        /// <inheritdoc />
        public override DefaultPortPresenter Setup(PortModel model)
        {
            base.Setup(model);
            return this;
        }


        /// <inheritdoc />
        public override DefaultPort Create() => new(Model);
    }
}