namespace AG.DS
{
    public interface IPortCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortModel, TPortCallback, TEdgeView}.OnPostConnect(EdgeBase)"/>
        /// </summary>
        void OnPostConnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortModel, TPortCallback, TEdgeView}.OnPreDisconnect(EdgeBase)"/>
        /// </summary>
        void OnPreDisconnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortModel, TPortCallback, TEdgeView}.OnPostConnectingEdgeDropOutside()"/>
        /// </summary>
        void OnPostConnectingEdgeDropOutside();
    }
}