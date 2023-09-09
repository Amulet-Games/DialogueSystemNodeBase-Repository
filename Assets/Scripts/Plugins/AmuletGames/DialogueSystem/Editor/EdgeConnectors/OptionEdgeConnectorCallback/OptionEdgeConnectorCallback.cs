using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeConnectorCallback : EdgeConnectorCallbackFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView,
        NodeCreateOptionConnectorWindow,
        OptionEdgeConnectorCallback
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
        public override void OnDropOutsidePort(Edge edge, Vector2 position)
        {
            if (edge.input != null)
            {
                // If the edge that user dropped is from a input port.
                NodeCreateConnectorWindow.Open
                (
                    horizontalAlignmentType: HorizontalAlignmentType.LEFT,

                    connectorPort: ConnectorPort,

                    toShowEntries: NodeCreateEntryProvider.OptionChannelInputEntries
                );
            }
            else
            {
                // If the edge that user dropped is from a output port.
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