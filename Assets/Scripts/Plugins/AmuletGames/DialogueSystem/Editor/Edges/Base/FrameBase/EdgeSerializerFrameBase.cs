namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeSerializerFrameBase
    <
        TPort,
        TEdge,
        TEdgeView,
        TEdgeModel
    >
        : EdgeSerializerBase
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeModel : EdgeModelBase
    {
        /// <summary>
        /// Reference of the edge view.
        /// </summary>
        protected TEdgeView View;


        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        protected TEdgeModel Model;


        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="view">The edge view to set for.</param>
        /// <param name="model">The edge model to set for.</param>
        public virtual void Save(TEdgeView view, TEdgeModel model)
        {
            View = view;
            Model = model;
        }


        /// <summary>
        /// Save the edge base values.
        /// </summary>
        protected void SaveEdgeBaseValues()
        {
            Model.InputPortGUID = View.Input.Guid;
            Model.OutputPortGUID = View.Output.Guid;
        }
    }
}