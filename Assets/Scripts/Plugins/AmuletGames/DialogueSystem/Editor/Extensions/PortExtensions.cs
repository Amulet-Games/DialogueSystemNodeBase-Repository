using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class PortExtensions
    {
        /// <summary>
        /// Add a new edge connector to the port.
        /// </summary>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create connector window</typeparam>
        /// <param name="port">Extension port</param>
        /// <param name="nodeCreateConnectorWindow">The node create connector window to set for.</param>
        /// <param name="nodeCreateWindowEntries">The node create window entries to set for.</param>
        /// <param name="edgeFocusable">The edge focusable value to set for.</param>
        /// <param name="edgeStyleSheet">The edge style sheet to set for.</param>
        public static void AddEdgeConnector<TNodeCreateConnectorWindow>
        (
            this PortBase port,
            TNodeCreateConnectorWindow nodeCreateConnectorWindow,
            List<SearchTreeEntry> nodeCreateWindowEntries,
            bool edgeFocusable,
            StyleSheet edgeStyleSheet
        )
            where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
        {
            var listener = new EdgeConnectorListener<TNodeCreateConnectorWindow>
            (
                connectorPort: port,
                nodeCreateConnectorWindow,
                nodeCreateWindowEntries,
                edgeFocusable,
                edgeStyleSheet
            );

            port.EdgeConnector = new EdgeConnector<EdgeBase>(listener);
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
            return port.capacity == Port.Capacity.Single;
        }


        /// <summary>
        /// Returns true if the port is added to the connect style.
        /// </summary>
        /// <param name="port">Extension port.</param>
        /// <returns>True if the port is added to the connect style.</returns>
        public static bool IsConnectStyle(this Port port)
        {
            return port.ClassListContains(StyleConfig.Port_Connect);
        }
    }
}