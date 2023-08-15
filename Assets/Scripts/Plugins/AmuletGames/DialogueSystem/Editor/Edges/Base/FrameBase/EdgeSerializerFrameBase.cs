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
        : NodeSerializerBase
        where TPort : PortBase
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
        where TEdgeModel : EdgeModelBase
    {
        /// <summary>
        /// Save the edge element values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <param name="model">The edge model to set for.</param>
        public virtual void Save(TEdge edge, TEdgeModel model)
        {
            // edge basic info
            {
                model.InputPortGUID = edge.input.name;
                model.OutputPortGUID = edge.output.name;
            }
        }
    }
}