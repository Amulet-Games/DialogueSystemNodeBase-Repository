using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreationConnectorWindow : NodeCreationWindowBase
    {
        /// <summary>
        /// The node creation entries to show when the window first opened up or reloaded.
        /// </summary>
        List<SearchTreeEntry> toShowEntries;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Create a new dialgoue system's node creation request window.
        /// <br>Since the class is a scriptable object, the method is also a constructor for the class.</br>
        /// </summary>
        /// <param name="graphViewer">Dialogue system's graph viewer module.</param>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        /// <returns>A new dialogue system's search window module.</returns>
        public static NodeCreationConnectorWindow CreateInstance
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow
        )
        {
            NodeCreationConnectorWindow instance;

            CreateInstance();

            SetupInternalRefs();

            SetupValues();

            return instance;

            void CreateInstance()
            {
                // Create a new search window instance.
                instance = CreateInstance<NodeCreationConnectorWindow>();
            }

            void SetupInternalRefs()
            {
                // Setup instance's internal references
                instance.DsWindow = dsWindow;
                instance.GraphViewer = graphViewer;
                instance.Details = new();
            }

            void SetupValues()
            {
                instance.isUpdatePositionSelectEntry = false;
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) =>
            toShowEntries;


        // ----------------------------- Update Context Services -----------------------------
        /// <summary>
        /// Method for Updating window's node creation details and entries.
        /// </summary>
        /// <param name="horizontalAlignType">The new horizontal align type to set for.</param>
        /// <param name="creationConnectorType">The new creation connector type to set for.</param>
        /// <param name="connectorPort">The new connector port reference to set for. </param>
        /// <param name="toShowSearchEntries">The new set of search entries to set for.</param>
        public void UpdateWindowContext
        (
            C_Alignment_HorizontalType horizontalAlignType,
            P_ConnectorType creationConnectorType,
            Port connectorPort,
            List<SearchTreeEntry> toShowSearchEntries
        )
        {
            // Update node creation details.
            Details.PreUpdateValues
            (
                horizontalAlignType,
                creationConnectorType,
                connectorPort
            );

            // Update toShowEntries.
            toShowEntries = toShowSearchEntries;
        }
    }
}