namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortPresenterFrameBase
    <
        TPort,
        TPortCreateDetail,
        TPortPresenter,
        TEdge,
        TEdgeView
    >
        : PortPresenterBase
        where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TPortCreateDetail : PortCreateDetailBase
        where TPortPresenter : PortPresenterFrameBase<TPort, TPortCreateDetail, TPortPresenter, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
    {
        /// <summary>
        /// Reference of the port create detail.
        /// </summary>
        protected TPortCreateDetail Detail;


        /// <summary>
        /// Setup for the port presenter frame base class.
        /// </summary>
        /// <returns>The after setup port presenter frame base class.</returns>
        public virtual TPortPresenter Setup(TPortCreateDetail detail)
        {
            Detail = detail;
            return null;
        }


        /// <summary>
        /// Create a new port element.
        /// </summary>
        /// <returns>A new port element.</returns>
        public abstract TPort Create();
    }
}