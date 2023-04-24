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
        /// Reference of the model module.
        /// </summary>
        public TEdgeModel Model;
    }
}