namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortPresenterFrameBase
    <
        TPort,
        TPortModel,
        TPortPresenter,
        TEdge,
        TEdgeView
    >
        : PortPresenterBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TPortModel : PortModel
        where TPortPresenter : PortPresenterFrameBase<TPort, TPortModel, TPortPresenter, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdge, TEdgeView>
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