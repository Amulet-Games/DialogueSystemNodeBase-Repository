using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        DefaultEdgeConnectorCallback,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override DefaultEdgeConnectorCallback Setup
        (
            NodeCreateDefaultConnectorWindow connectorWindow,
            PortBase connectorPort,
            StyleSheet connectorEdgeStyleSheet
        )
        {
            base.Setup(connectorWindow, connectorPort, connectorEdgeStyleSheet);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        protected override void OnDropOutsidePort(EdgeBase edge, Vector2 position)
        {
            var isDropFromInput = ConnectorPort.IsInput();
            var horizontalAlignmentType = isDropFromInput ? HorizontalAlignmentType.LEFT : HorizontalAlignmentType.RIGHT;
            var toShowEntries = isDropFromInput
                ? NodeCreateEntryProvider.DefaultNodeInputEntries
                : NodeCreateEntryProvider.DefaultNodeOutputEntries;

            NodeCreateConnectorWindow.Open
            (
                horizontalAlignmentType: horizontalAlignmentType,

                connectorPort: ConnectorPort,

                connectorEdgeStyleSheet: ConnectorEdgeStyleSheet,

                toShowEntries: toShowEntries
            );

            ConnectorPort.Callback.OnPostConnectingEdgeDropOutside();
        }
    }
}