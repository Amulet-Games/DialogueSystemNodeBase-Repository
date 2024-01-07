namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortPresenterFrameBase
    <
        TPort,
        TPortPresenter
    >
        : PortPresenterBase
        where TPort : Port<TPort>
        where TPortPresenter : PortPresenterFrameBase<TPort, TPortPresenter>
    {
        /// <summary>
        /// Create a new port element.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        /// <returns>A new port element.</returns>
        public abstract TPort Create(PortModel model);
    }
}