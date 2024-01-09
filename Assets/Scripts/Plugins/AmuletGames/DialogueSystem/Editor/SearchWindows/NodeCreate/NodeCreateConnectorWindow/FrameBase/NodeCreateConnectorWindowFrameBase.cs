using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
        : NodeCreateWindowFrameBase
    <
        NodeCreateConnectorCallback,
        NodeCreateConnectorDetail,
        NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
    >
        where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
    {
        /// <inheritdoc />
        protected override List<SearchTreeEntry> ToShowEntries => toShowEntries;


        /// <summary>
        /// The node create entries of the window.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        /// <summary>
        /// Setup for the node create connector window frame base class.
        /// </summary>
        /// <param name="callback">The node create connector callback to set for.</param>
        /// <param name="detail">The node create connector detail to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <returns>A new node create connector window.</returns>
        public virtual new TNodeCreateConnectorWindow Setup
        (
            NodeCreateConnectorCallback callback,
            NodeCreateConnectorDetail detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
            return null;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Open the node create connector window.
        /// </summary>
        /// <param name="horizontalAlignmentType">The horizontal align type to set for.</param>
        /// <param name="connectorPort">The connector port to set for. </param>
        /// <param name="edgeModel">The edge model to set for. </param>
        /// <param name="toShowEntries">The to show search tree entries to set for.</param>
        public void Open
        (
            HorizontalAlignmentType horizontalAlignmentType,
            PortBase connectorPort,
            EdgeModel edgeModel,
            List<SearchTreeEntry> toShowEntries
        )
        {
            // Update detail
            {
                Detail.SetTypeHorizontalAlignment(value: horizontalAlignmentType);
                Detail.SetPortConnector(value: connectorPort);
                Detail.SetEdgeModel(value: edgeModel);
                
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