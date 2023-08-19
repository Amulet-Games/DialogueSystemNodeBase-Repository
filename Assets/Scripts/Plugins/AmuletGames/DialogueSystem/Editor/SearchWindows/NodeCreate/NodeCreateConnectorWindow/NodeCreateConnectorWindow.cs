using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreateConnectorWindow : NodeCreateWindowFrameBase
    <
        NodeCreateConnectorWindow,
        NodeCreateConnectorCallback,
        NodeCreateConnectorDetail
    >
    {
        /// <inheritdoc />
        protected override List<SearchTreeEntry> ToShowEntries => toShowEntries;


        /// <summary>
        /// The node create entries of the window.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        /// <inheritdoc />
        public override NodeCreateConnectorWindow Setup
        (
            NodeCreateConnectorCallback callback,
            NodeCreateConnectorDetail detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return this;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Open the node create connector window.
        /// </summary>
        /// <param name="horizontalAlignmentType">The horizontal align type to set for.</param>
        /// <param name="connectorType">The connector type to set for. </param>
        /// <param name="connectorPort">The connector port to set for. </param>
        /// <param name="toShowEntries">The to show search tree entries to set for.</param>
        public void Open
        (
            HorizontalAlignmentType horizontalAlignmentType,
            ConnectorType connectorType,
            PortBase connectorPort,
            List<SearchTreeEntry> toShowEntries
        )
        {
            // Update detail
            {
                Detail.SetTypeHorizontalAlignment(value: horizontalAlignmentType);
                Detail.SetTypeConnector(value: connectorType);
                Detail.SetPortConnector(value: connectorPort);

                this.toShowEntries = toShowEntries;
            }

            // Open window
            {
                SearchWindow.Open
                (
                    context: new SearchWindowContext(GraphViewer.ScreenMousePosition),
                    provider: this
                );
            }
        }
    }
}