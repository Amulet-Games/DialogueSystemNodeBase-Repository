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
        /// <param name="graphViewer">Dialogue system's graph view module.</param>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
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
                instance.Details = new NodeCreationDetails(C_Alignment_HorizontalType.Middle, null);
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