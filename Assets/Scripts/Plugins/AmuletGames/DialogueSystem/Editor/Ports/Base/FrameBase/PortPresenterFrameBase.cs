namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortPresenterFrameBase
    <
        TPort,
        TPortModel,
        TPortPresenter,
        TEdgeView
    >
        : PortPresenterBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TPortPresenter : PortPresenterFrameBase<TPort, TPortModel, TPortPresenter, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
    {
        /// <summary>
        /// Reference of the port model.
        /// </summary>
        protected TPortModel Model;


        /// <summary>
        /// Setup for the port presenter frame base class.
        /// </summary>
        public virtual TPortPresenter Setup(TPortModel model)
        {
            Model = model;
            return null;
        }


        /// <summary>
        /// Create a new port element.
        /// </summary>
        /// <returns>A new port element.</returns>
        public abstract TPort Create();
    }
}