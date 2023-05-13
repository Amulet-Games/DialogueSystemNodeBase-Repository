using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreationConnectorWindow : NodeCreationWindowBase
    {
        /// <summary>
        /// The node creation entries of the connector window.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Create a new node creation connector window.
        /// <br>Since the class is a scriptable object, the method is also a constructor for the class.</br>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window module to set for.</param>
        /// <returns>A new node creation connector window.</returns>
        public static NodeCreationConnectorWindow CreateInstance
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow
        )
        {
            var instance = CreateInstance<NodeCreationConnectorWindow>();

            instance.DsWindow = dsWindow;
            instance.GraphViewer = graphViewer;
            instance.Details = new();
            instance.isUpdatePositionSelectEntry = false;

            return instance;
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => toShowEntries;


        // ----------------------------- Update Context -----------------------------
        /// <summary>
        /// Method for Updating window's node creation details and entries.
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
            Details.SetTypeHorizontalAligment(value: horizontalAlignmentType);
            Details.SetTypeConnector(value: connectorType);
            Details.SetPortConnector(value: connectorPort);

            toShowEntries = toShowSearchEntries;
        }
    }
}