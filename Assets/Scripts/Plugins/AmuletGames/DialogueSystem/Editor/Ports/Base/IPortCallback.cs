namespace AG.DS
{
    public interface IPortCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortCallback}.OnPostConnect(EdgeBase)"/>
        /// </summary>
        void OnPostConnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortCallback}.OnPreDisconnect(EdgeBase)"/>
        /// </summary>
        void OnPreDisconnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallbackFrameBase{TPort, TPortCallback}.OnPostConnectingEdgeDropOutside()"/>
        /// </summary>
        void OnPostConnectingEdgeDropOutside();
    }
}