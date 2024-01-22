using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public static class PortExtensions
    {
        /// <summary>
        /// Add a new edge connector to the port.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window to set for.</param>
        /// <param name="edgeFocusable">The edge focusable value to set for.</param>
        /// <param name="edgeStyleSheet">The edge style sheet to set for.</param>
        public static void AddEdgeConnector
        (
            this Port port,
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            bool edgeFocusable,
            StyleSheet edgeStyleSheet
        )
        {
            var listener = new EdgeConnectorListener
            (
                connectorPort: port,
                edgeConnectorSearchWindowView,
                edgeFocusable,
                edgeStyleSheet
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