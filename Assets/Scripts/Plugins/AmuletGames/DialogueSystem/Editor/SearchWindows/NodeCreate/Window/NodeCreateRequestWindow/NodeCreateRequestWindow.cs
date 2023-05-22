using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreateRequestWindow : NodeCreateWindowBase
    {
        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) =>
            NodeCreateEntryProvider.NodeCreateRequestEntries;
    }
}