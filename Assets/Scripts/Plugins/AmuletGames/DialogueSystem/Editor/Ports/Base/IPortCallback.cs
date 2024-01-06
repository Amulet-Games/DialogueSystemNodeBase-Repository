namespace AG.DS
{
    public interface IPortCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortModel, TEdgeView}.OnConnect(EdgeBase)"/>
        /// </summary>
        void OnPostConnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortModel, TEdgeView}.OnDisconnect(EdgeBase)"/>
        /// </summary>
        void OnPreDisconnect(EdgeBase edge);
    }
}