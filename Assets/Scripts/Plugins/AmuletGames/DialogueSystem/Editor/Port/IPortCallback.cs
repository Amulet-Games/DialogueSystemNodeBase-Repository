namespace AG.DS
{
    public interface IPortCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPostConnect(EdgeBase)"/>
        /// </summary>
        void OnPostConnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPreDisconnect(EdgeBase)"/>
        /// </summary>
        void OnPreDisconnect(EdgeBase edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPostConnectingEdgeDropOutside()"/>
        /// </summary>
        void OnPostConnectingEdgeDropOutside();
    }
}