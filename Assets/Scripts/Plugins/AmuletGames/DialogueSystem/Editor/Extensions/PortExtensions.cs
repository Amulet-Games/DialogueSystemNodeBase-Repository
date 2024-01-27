using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public static class PortExtensions
    {
        /// <summary>
        /// Add a new edge connector to the port.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <param name="edgeConnectorListenerModel">The edge connector listener model to set for.</param>
        public static void AddEdgeConnector
        (
            this Port port,
            EdgeConnectorListenerModel edgeConnectorListenerModel
        )
        {
            var listener = new EdgeConnectorListener
            (
                connectorPort: port,
                model: edgeConnectorListenerModel
            );

            port.EdgeConnector = new EdgeConnector<Edge>(listener);
        }


        /// <summary>
        /// Returns true if the port's direction is input.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's direction is input.</returns>
        public static bool IsInput(this Port port)
        {
            return port.direction == Direction.Input;
        }


        /// <summary>
        /// Returns true if the port's capacity is single.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's capacity is single.</returns>
        public static bool IsSingle(this Port port)
        {
            return port.capacity == Capacity.Single;
        }
    }
}