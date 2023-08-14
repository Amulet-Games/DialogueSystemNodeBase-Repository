namespace AG.DS
{
    public interface IEdgeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="EdgeCallbackFrameBase{TPort, TEdge, TEdgeView, TEdgeCallback}.OnPreManualRemove"/>
        /// </summary>
        void OnPreManualRemove(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="EdgeCallbackFrameBase{TPort, TEdge, TEdgeView, TEdgeCallback}.OnPostManualRemove"/>
        /// </summary>
        void OnPostManualRemove(GraphViewer graphViewer);
    }
}