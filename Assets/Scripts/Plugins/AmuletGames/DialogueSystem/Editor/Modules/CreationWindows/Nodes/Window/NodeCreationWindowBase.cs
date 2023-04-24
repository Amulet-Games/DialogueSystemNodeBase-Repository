using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeCreationWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the dialogue system's graph viewer module.
        /// </summary>
        protected GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the dialogue system's editor window.
        /// </summary>
        protected DialogueEditorWindow DsWindow;


        /// <summary>
        /// Reference of the dialogue system's node creation details.
        /// </summary>
        protected NodeCreationDetails Details;


        /// <summary>
        /// Does the window update its cached screen mouse position again when an node creation entry is selected.
        /// </summary>
        protected bool isUpdatePositionSelectEntry;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Executed when user selects an entry in the search tree list.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</para>
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            Vector2 createPosition;

            InvokeSelectedEntryEvent();

            CalculateGraphMousePosition();

            PostUpdateCreationDetails();

            CreateNodes();

            return true;

            void InvokeSelectedEntryEvent()
            {
                TreeEntrySelectedEvent.Invoke();
            }

            void CalculateGraphMousePosition()
            {
                // The 2d direction from mouse screen position to window center position.
                Vector2 preWindowCenterDir;
                if (isUpdatePositionSelectEntry)
                {
                    // Update mouse position again.
                    preWindowCenterDir = GraphViewer.GetCurrentEventMousePosition() - DsWindow.position.position;
                }
                else
                {
                    // Use the mouse position which was cached earlier.
                    preWindowCenterDir = context.screenMousePosition - DsWindow.position.position;
                }
                
                // Get the screen space mouse position and convert its coordinates to window(?) space.
                Vector2 postWindowCenterDir = DsWindow.rootVisualElement.ChangeCoordinatesTo
                (
                    dest: DsWindow.rootVisualElement.parent,
                    point: preWindowCenterDir
                );

                // And calculate its position in the graph viewer.
                createPosition = GraphViewer.contentViewContainer.WorldToLocal(p: postWindowCenterDir);
            }

            void PostUpdateCreationDetails()
            {
                // Update the node creation details.
                Details.SetPositionCreate(value: createPosition);
            }

            void CreateNodes()
            {
                // Retrieves the underlying node type by the convering the entryId inside the search entry.
                var selectedNodeType = (N_NodeType)((NodeCreationEntry)searchTreeEntry).EntryId;
                switch (selectedNodeType)
                {
                    case N_NodeType.Boolean:
                        new BooleanNode(Details, GraphViewer);
                        break;
                    case N_NodeType.Dialogue:
                        new DialogueNode(Details, GraphViewer);
                        break;
                    case N_NodeType.End:
                        new EndNode(Details, GraphViewer);
                        break;
                    case N_NodeType.Event:
                        new EventNode(Details, GraphViewer);
                        break;
                    case N_NodeType.OptionBranch:
                        new OptionBranchNode(Details, GraphViewer);
                        break;
                    case N_NodeType.OptionRoot:
                        new OptionRootNode(Details, GraphViewer);
                        break;
                    case N_NodeType.Preview:
                        new PreviewNode(Details, GraphViewer);
                        break;
                    case N_NodeType.Start:
                        new StartNode(Details, GraphViewer);
                        break;
                    case N_NodeType.Story:
                        new StoryNode(Details, GraphViewer);
                        break;
                }
            }
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Generates data to populate the search window.
        /// <br>This method is invoked when the SearchWindow first opens and when it is reloaded.</br>
        /// <para>Read More https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html</para>
        /// </summary>
        /// <param name="context">Contextual data initially passed the window when first created.</param>
        /// <returns>Returns the list of SearchTreeEntry objects displayed in the search window.</returns>
        public abstract List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context);


        // ----------------------------- Open Window -----------------------------
        /// <summary>
        /// Open the node creation request search window.
        /// </summary>
        /// <param name="screenPositionToShow">The screen position to use to show the search window.</param>
        public void Open(Vector2 screenPositionToShow)
        {
            // Show window.
            SearchWindow.Open
            (
                context: new SearchWindowContext(screenPositionToShow),
                provider: this
            );
        }
    }
}