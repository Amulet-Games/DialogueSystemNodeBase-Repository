using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        OptionPort,
        OptionPortModel,
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
        protected override void OnDropOutsidePort(Edge<OptionPort, OptionPortModel, OptionEdgeView> edge, Vector2 position)
        {
            if (ConnectorPort.IsInput())
            {
                // If the edge that user dropped is from a input port.
                {
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
                    NodeCreateConnectorWindow.Open
                    (
                        horizontalAlignmentType: HorizontalAlignmentType.RIGHT,

                        connectorPort: ConnectorPort,

                        toShowEntries: NodeCreateEntryProvider.OptionChannelOutputEntries
                    );
                }
            }

            ConnectorPort.Callback.OnPostConnectingEdgeDropOutside();
        }
    }
}