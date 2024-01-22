namespace AG.DS
{
    public interface IPortCallback
    {
        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPostConnect(Edge)"/>
        /// </summary>
        void OnPostConnect(Edge edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPreDisconnect(Edge)"/>
        /// </summary>
        void OnPreDisconnect(Edge edge);


        /// <summary>
        /// Read more:
        /// <see cref="PortCallback.OnPostConnectingEdgeDropOutside()"/>
        /// </summary>
        void OnPostConnectingEdgeDropOutside();
    }
}