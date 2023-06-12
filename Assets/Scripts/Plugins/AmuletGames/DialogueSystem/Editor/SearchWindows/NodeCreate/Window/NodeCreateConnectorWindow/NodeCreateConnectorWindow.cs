using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreateConnectorWindow : NodeCreateWindowBase
    {
        /// <summary>
        /// The node create entries of the connector window.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => toShowEntries;


        // ----------------------------- Update Context -----------------------------
        /// <summary>
        /// Method for updating the window's node create details and entries.
        /// </summary>
        /// <param name="horizontalAlignmentType">The horizontal align type to set for.</param>
        /// <param name="connectorType">The connector type to set for. </param>
        /// <param name="connectorPort">The connector port to set for. </param>
        /// <param name="toShowSearchEntries">The search entries to set for.</param>
        public void UpdateWindowContext
        (
            HorizontalAlignmentType horizontalAlignmentType,
            ConnectorType connectorType,
            PortBase connectorPort,
            List<SearchTreeEntry> toShowSearchEntries
        )
        {
            Details.SetTypeHorizontalAlignment(value: horizontalAlignmentType);
            Details.SetTypeConnector(value: connectorType);
            Details.SetPortConnector(value: connectorPort);

            toShowEntries = toShowSearchEntries;
        }
    }
}