using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorWindow
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : NodeCreateWindowFrameBase<NodeCreateConnectorCallback>
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
    {
        /// <summary>
        /// Reference of the node create detail.
        /// </summary>
        public NodeCreateConnectorDetail<TPort, TEdge, TEdgeView> detail;


        /// <inheritdoc />
        protected override List<SearchTreeEntry> ToShowEntries => toShowEntries;


        /// <summary>
        /// The node create entries of the window.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        /// <summary>
        /// Setup for the node create connector window class.
        /// </summary>
        /// <param name="callback">The node create callback to set for.</param>
        /// <param name="detail">The node create connector detail to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The after setup node create connector window.</returns>
        public NodeCreateConnectorWindow<TPort, TEdge, TEdgeView> Setup
        (
            NodeCreateConnectorCallback callback,
            NodeCreateConnectorDetail<TPort, TEdge, TEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            Setup(callback, graphViewer);
            this.detail = detail;

            return this;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Open the node create connector window.
        /// </summary>
        /// <param name="horizontalAlignmentType">The horizontal align type to set for.</param>
        /// <param name="connectorPort">The connector port to set for. </param>
        /// <param name="toShowEntries">The to show search tree entries to set for.</param>
        public void Open
        (
            HorizontalAlignmentType horizontalAlignmentType,
            TPort connectorPort,
            List<SearchTreeEntry> toShowEntries
        )
        {
            // Update detail
            {
                detail.SetTypeHorizontalAlignment(value: horizontalAlignmentType);
                detail.SetPortConnector(value: connectorPort);

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