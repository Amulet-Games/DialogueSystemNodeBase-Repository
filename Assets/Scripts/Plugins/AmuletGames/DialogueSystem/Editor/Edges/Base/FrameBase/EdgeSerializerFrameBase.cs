namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeSerializerFrameBase
    <
        TPort,
        TPortCreateDetail,
        TEdge,
        TEdgeView,
        TEdgeData
    >
        : EdgeSerializerBase
        where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TPortCreateDetail : PortCreateDetailBase
        where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
        where TEdgeData : EdgeDataBase
    {
        /// <summary>
        /// Reference of the edge view.
        /// </summary>
        protected TEdgeView View;


        /// <summary>
        /// Reference of the edge data.
        /// </summary>
        protected TEdgeData Data;


        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="view">The edge view to set for.</param>
        /// <param name="data">The edge data to set for.</param>
        public virtual void Save(TEdgeView view, TEdgeData data)
        {
            View = view;
            Data = data;
        }


        /// <summary>
        /// Save the edge base values.
        /// </summary>
        protected void SaveEdgeBaseValues()
        {
            Data.InputPortGUID = View.Input.Guid;
            Data.OutputPortGUID = View.Output.Guid;
        }
    }
}