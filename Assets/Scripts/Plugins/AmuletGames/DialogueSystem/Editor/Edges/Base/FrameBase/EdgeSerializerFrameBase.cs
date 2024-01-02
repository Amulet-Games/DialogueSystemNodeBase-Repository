namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeSerializerFrameBase
    <
        TPort,
        TPortModel,
        TEdgeView,
        TEdgeData
    >
        : EdgeSerializerBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
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