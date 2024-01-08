using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        OptionEdgeConnectorCallback,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override OptionEdgeConnectorCallback Setup
        (
            PortBase connectorPort,
            StyleSheet connectorEdgeStyleSheet,
            NodeCreateOptionConnectorWindow connectorWindow
        )
        {
            base.Setup(connectorPort, connectorEdgeStyleSheet, connectorWindow);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        protected override void OnDropOutsidePort(EdgeBase edge, Vector2 position)
        {
            var isDropFromInput = ConnectorPort.IsInput();
            var horizontalAlignmentType = isDropFromInput ? HorizontalAlignmentType.LEFT : HorizontalAlignmentType.RIGHT;
            var toShowEntries = isDropFromInput
                ? NodeCreateEntryProvider.OptionChannelInputEntries
                : NodeCreateEntryProvider.OptionChannelOutputEntries;

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