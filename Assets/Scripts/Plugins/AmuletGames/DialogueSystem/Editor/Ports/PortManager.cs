using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class PortManager
    {
        
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static PortManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the port manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }

        // ----------------------------- Create -----------------------------
        /// <summary>
        /// Method for creating a new option port element.
        /// </summary>
        /// <param name="direction">The direction to set for.</param>
        /// <returns>A new option port element.</returns>
        public OptionPort CreateOption(Direction direction)
        {
            var port = new OptionPort(direction);
            var edgeConnector = CreateEdgeConnector<OptionPort, OptionEdge, OptionEdgeView, OptionEdgeConnectorCallback>();

            port.Setup(edgeConnector);
            return port;
        }


        /// <summary>
        /// Method for creating a new default port element. 
        /// </summary>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="portName">The port name to set for.</param>
        /// <param name="isSibling">The isSibling value to set for.</param>
        /// 
        /// <returns>A new default port element.</returns>
        public DefaultPort CreateDefault
        (
            Direction direction,
            Capacity capacity,
            string portName,
            bool isSibling = false
        )
        {
            var port = new DefaultPort(direction, capacity);
            var edgeConnector = CreateEdgeConnector<DefaultPort, DefaultEdge, DefaultEdgeView, DefaultEdgeConnectorCallback>();

            port.Setup(edgeConnector, portName, isSibling);
            return port;
        }


        /// <summary>
        /// Method for creating a new edge connector.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TEdgeConnectorCallback">Type connector callback</typeparam>
        /// 
        /// <returns>A new edge connector.</returns>
        EdgeConnector CreateEdgeConnector<TPort, TEdge, TEdgeView, TEdgeConnectorCallback>()
            where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
            where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>, new()
            where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TPort, TEdge, TEdgeConnectorCallback>, new()
        {
            var edgeConnectorCallback = new TEdgeConnectorCallback();
            return new EdgeConnector<TEdge>(edgeConnectorCallback);
        }
    }
}