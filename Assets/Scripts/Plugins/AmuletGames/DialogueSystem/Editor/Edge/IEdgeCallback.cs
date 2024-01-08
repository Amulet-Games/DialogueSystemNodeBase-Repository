namespace AG.DS
{
    public interface IEdgeCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="EdgeCallbackFrameBase{TPort, TEdge, TEdgeCallback}.OnPreRemoveByUser"/>
        /// </summary>
        void OnPreRemoveByUser(GraphViewer graphViewer);


        /// <summary>
        /// Read more:
        /// <see cref="EdgeCallbackFrameBase{TPort, TEdge, TEdgeCallback}.OnPostRemoveByUser"/>
        /// </summary>
        void OnPostRemoveByUser(GraphViewer graphViewer);
    }
}