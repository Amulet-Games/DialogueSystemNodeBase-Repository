using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        OptionPort,
        OptionPortModel,
        OptionEdge,
        OptionEdgeView,
        OptionEdgeConnectorCallback,
        NodeCreateOptionConnectorWindow
    >
    {
        /// <inheritdoc />
        public override OptionEdgeConnectorCallback Setup
        (
            OptionPort connectorPort,
            NodeCreateOptionConnectorWindow connectorWindow
        )
        {
            base.Setup(connectorPort, connectorWindow);
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        protected override void OnDropOutsidePort(OptionEdge edge, Vector2 position)
        {
            if (ConnectorPort.IsInput())
            {
                // If the edge that user dropped is from a input port.
                {
                    edge.View?.Input.HideConnectStyle();

                    NodeCreateConnectorWindow.Open
                    (
                        horizontalAlignmentType: HorizontalAlignmentType.LEFT,

                        connectorPort: ConnectorPort,

                        toShowEntries: NodeCreateEntryProvider.OptionChannelInputEntries
                    );
                }
            }
            else
            {
                // If the edge that user dropped is from a output port.
                {
                    edge.View?.Output.HideConnectStyle();

                    NodeCreateConnectorWindow.Open
                    (
                        horizontalAlignmentType: HorizontalAlignmentType.RIGHT,

                        connectorPort: ConnectorPort,

                        toShowEntries: NodeCreateEntryProvider.OptionChannelOutputEntries
                    );
                }
            }
        }
    }
}