using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSNodeCreationConnectorWindow : DSNodeCreationWindowBase
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
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        /// <returns>A new dialogue system's search window module.</returns>
        public static DSNodeCreationConnectorWindow CreateInstance(DSGraphView graphView, DialogueEditorWindow dsWindow)
        {
            DSNodeCreationConnectorWindow instance;

            CreateInstance();

            SetupInternalRefs();

            SetupValues();

            return instance;

            void CreateInstance()
            {
                // Create a new search window instance.
                instance = CreateInstance<DSNodeCreationConnectorWindow>();
            }

            void SetupInternalRefs()
            {
                // Setup instance's internal references
                instance.DsWindow = dsWindow;
                instance.GraphView = graphView;
                instance.Details = new DSNodeCreationDetails();
            }

            void SetupValues()
            {
                instance.isUpdatePositionSelectEntry = false;
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
            =>
            toShowEntries;


        // ----------------------------- Update Context Services -----------------------------
        /// <summary>
        /// Method for Updating window's node creation details and entries.
        /// </summary>
        /// <param name="horizontalAlignType"></param>
        /// <param name="nodeCreationConnectorType"></param>
        /// <param name="connectorPort"></param>
        /// <param name="connectorEntries"></param>
        public void UpdateWindowContext
        (
            C_Alignment_HorizontalType horizontalAlignType,
            P_ConnectorType nodeCreationConnectorType,
            Port connectorPort,
            List<SearchTreeEntry> connectorEntries
        )
        {
            // Update node creation details.
            Details.PreUpdateValues
            (
                horizontalAlignType,
                nodeCreationConnectorType,
                connectorPort
            );

            // Update toShowEntries.
            toShowEntries = connectorEntries;
        }
    }
}