namespace AG.DS
{
    public abstract class EdgeFrameBase
    <
        TEdgeModel
    >
        : EdgeBase
        where TEdgeModel : EdgeModelBase
    {
        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        public TEdgeModel Model;
    }
}