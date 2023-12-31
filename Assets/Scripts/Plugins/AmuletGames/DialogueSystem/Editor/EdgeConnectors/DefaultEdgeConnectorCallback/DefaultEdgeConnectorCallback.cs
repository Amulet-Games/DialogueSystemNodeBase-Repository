using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView,
        DefaultEdgeConnectorCallback,
        NodeCreateDefaultConnectorWindow
    >
    {
        /// <inheritdoc />
        public override DefaultEdgeConnectorCallback Setup
        (
            DefaultPort connectorPort,
            NodeCreateDefaultConnectorWindow connectorWindow
        )
        {
            base.Setup(connectorPort, connectorWindow);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        protected override void OnDropOutsidePort(DefaultEdge edge, Vector2 position)
        {
            if (ConnectorPort.IsInput())
            {
                // If the edge that user dropped is from a input port.
                NodeCreateConnectorWindow.Open
                (
                    horizontalAlignmentType: HorizontalAlignmentType.LEFT,

                    connectorPort: ConnectorPort,

                    toShowEntries: NodeCreateEntryProvider.DefaultNodeInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
                NodeCreateConnectorWindow.Open
                (
                    horizontalAlignmentType: HorizontalAlignmentType.RIGHT,

                    connectorPort: ConnectorPort,

                    toShowEntries: NodeCreateEntryProvider.DefaultNodeOutputEntries
                );
            }
        }
    }
}