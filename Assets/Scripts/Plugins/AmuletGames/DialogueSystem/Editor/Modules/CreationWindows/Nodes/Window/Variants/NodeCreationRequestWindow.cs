using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreationRequestWindow : NodeCreationWindowBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Create a new dialgoue system's node creation request window.
        /// <br>Since the class is a scriptable object, the method is also a constructor for the class.</br>
        /// </summary>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        /// <param name="dsWindow">The editor window module to set for.</param>
        /// <returns>A new dialogue system's search window module.</returns>
        public static NodeCreationRequestWindow CreateInstance
        (
            GraphViewer graphViewer,
            DialogueEditorWindow dsWindow
        )
        {
            NodeCreationRequestWindow instance;

            CreateInstance();

            SetupRefs();

            SetupValues();

            return instance;

            void CreateInstance()
            {
                // Create a new search window instance.
                instance = CreateInstance<NodeCreationRequestWindow>();
            }

            void SetupRefs()
            {
                // Setup instance's internal references
                instance.GraphViewer = graphViewer;
                instance.DsWindow = dsWindow;
                instance.Details = new
                (
                    horizontalAlignType: HorizontalAlignmentType.MIDDLE,
                    connectorPort: null
                );
            }

            void SetupValues()
            {
                instance.isUpdatePositionSelectEntry = true;
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <inheritdoc />
        public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) =>
            NodeCreationEntriesProvider.NodeCreationRequestEntries;
    }
}