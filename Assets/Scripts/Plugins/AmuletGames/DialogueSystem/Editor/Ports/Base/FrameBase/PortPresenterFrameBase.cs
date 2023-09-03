namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortPresenterFrameBase
    <
        TPort,
        TEdge,
        TEdgeView,
        TPortPresenter
    >
        : PortPresenterBase
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
        where TPortPresenter : PortPresenterFrameBase<TPort, TEdge, TEdgeView, TPortPresenter>
    {
        /// <summary>
        /// Reference of the port create detail
        /// </summary>
        protected PortCreateDetail Detail;


        /// <summary>
        /// Setup for the port presenter frame base class.
        /// </summary>
        /// <returns>The after setup port presenter frame base class.</returns>
        public virtual TPortPresenter Setup(PortCreateDetail detail)
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