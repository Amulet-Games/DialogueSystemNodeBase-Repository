namespace AG.DS
{
    /// <inheritdoc />
    public abstract class EdgeSerializerFrameBase
    <
        TPort,
        TPortModel,
        TEdgeData
    >
        : EdgeSerializerBase
        where TPort : PortFrameBase<TPort, TPortModel>
        where TPortModel : PortModel
        where TEdgeData : EdgeDataBase
    {
        /// <summary>
        /// Reference of the edge view.
        /// </summary>
        protected Edge<TPort, TPortModel> Edge;


        /// <summary>
        /// Reference of the edge data.
        /// </summary>
        protected TEdgeData Data;


        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="data">The edge data to set for.</param>
        public virtual void Save(Edge<TPort, TPortModel> edge, TEdgeData data)
        {
            Edge = edge;
            Data = data;
        }


        /// <summary>
        /// Save the edge base values.
        /// </summary>
        protected void SaveEdgeBaseValues()
        {
            Data.InputPortGUID = Edge.Input.Guid;
            Data.OutputPortGUID = Edge.Output.Guid;
        }
    }
}