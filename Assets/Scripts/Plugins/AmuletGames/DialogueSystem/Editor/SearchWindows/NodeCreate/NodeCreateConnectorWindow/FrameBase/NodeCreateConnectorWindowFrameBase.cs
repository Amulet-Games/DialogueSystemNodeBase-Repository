using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCreateConnectorWindowFrameBase
    <
        TPort,
        TPortModel,
        TEdgeView,
        TNodeCreateConnectorWindow
    >
        : NodeCreateWindowFrameBase
    <
        NodeCreateConnectorCallback<TPort, TPortModel, TEdgeView>,
        NodeCreateConnectorDetail<TPort, TPortModel, TEdgeView>,
        NodeCreateConnectorWindowFrameBase<TPort, TPortModel, TEdgeView, TNodeCreateConnectorWindow>
    >
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
        where TNodeCreateConnectorWindow : NodeCreateConnectorWindowFrameBase<TPort, TPortModel, TEdgeView, TNodeCreateConnectorWindow>
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
            NodeCreateConnectorCallback<TPort, TPortModel, TEdgeView> callback,
            NodeCreateConnectorDetail<TPort, TPortModel, TEdgeView> detail,
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
                Detail.SetTypeHorizontalAlignment(value: horizontalAlignmentType);
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