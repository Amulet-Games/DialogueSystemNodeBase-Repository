namespace AG.DS
{
    public abstract class EdgePresenterFrameBase
    <
        TEdge,
        TEdgeModel,
        TPort
    >
        : EdgePresenterBase
        where TEdge : EdgeBase
        where TEdgeModel : EdgeModelFrameBase<TPort>
        where TPort : PortBase
    {
        /// <summary>
        /// Method for creating a new type edge element.
        /// </summary>
        /// <param name="model">The type edge model module to set for.</param>
        /// <returns>A new type edge element.</returns>
        public abstract TEdge CreateElements(TEdgeModel model);
    }
}