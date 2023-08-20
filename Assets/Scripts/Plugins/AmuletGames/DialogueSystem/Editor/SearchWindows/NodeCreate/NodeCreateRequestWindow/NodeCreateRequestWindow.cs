using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateRequestWindow : NodeCreateWindowFrameBase
    <
        NodeCreateRequestWindow,
        NodeCreateRequestCallback,
        NodeCreateRequestDetail
    >
    {
        /// <inheritdoc />
        protected override List<SearchTreeEntry> ToShowEntries
        {
            get => NodeCreateEntryProvider.NodeCreateRequestEntries;
        }


        /// <inheritdoc />
        public override NodeCreateRequestWindow Setup
        (
            NodeCreateRequestCallback callback,
            NodeCreateRequestDetail detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(callback, detail, graphViewer);
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