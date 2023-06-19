using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreateRequestWindow : NodeCreateWindowBase
    {
        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            return NodeCreateEntryProvider.NodeCreateRequestEntries;
        }


        // ----------------------------- Update Node Create Details -----------------------------
        /// <summary>
        /// Method for updating the node create details
        /// </summary>
        public void UpdateNodeCreateDetails()
        {
            Details.SetTypeHorizontalAlignment(value: HorizontalAlignmentType.MIDDLE);
            Details.SetTypeConnector(value: ConnectorType.NONE);
            Details.SetPortConnector(value: null);
        }
    }
}