using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateRequestWindow
        : NodeCreateWindowFrameBase<NodeCreateRequestCallback>
    {
        /// <summary>
        /// Reference of the node create detail.
        /// </summary>
        public NodeCreateRequestDetail detail;


        /// <inheritdoc />
        protected override List<SearchTreeEntry> ToShowEntries
        {
            get => NodeCreateEntryProvider.NodeCreateRequestEntries;
        }


        /// <summary>
        /// Setup for the node create request window class.
        /// </summary>
        /// <param name="callback">The node create callback to set for.</param>
        /// <param name="detail">The node create request detail to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The after setup node create request window.</returns>
        public NodeCreateRequestWindow Setup
        (
            NodeCreateRequestCallback callback,
            NodeCreateRequestDetail detail,
            GraphViewer graphViewer
        )
        {
            Setup(callback, graphViewer);
            this.detail = detail;

            return this;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Open the node create request window.
        /// </summary>
        /// <param name="openScreenPosition">The screen position to open the search tree window to set for.</param>
        public void Open(Vector2 openScreenPosition = default)
        {
            SearchWindow.Open
            (
                context: new SearchWindowContext
                (
                    openScreenPosition == default
                        ? GraphViewer.ScreenMousePosition
                        : openScreenPosition
                ),
                provider: this
            );
        }
    }
}