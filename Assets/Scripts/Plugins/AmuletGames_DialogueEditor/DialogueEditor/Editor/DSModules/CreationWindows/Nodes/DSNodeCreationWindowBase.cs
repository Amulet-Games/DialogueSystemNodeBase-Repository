using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public abstract class DSNodeCreationWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        protected DSGraphView GraphView;


        /// <summary>
        /// Reference of the dialogue system's editor window.
        /// </summary>
        protected DialogueEditorWindow DsWindow;


        /// <summary>
        /// Reference of the dialogue system's node creation details.
        /// </summary>
        protected DSNodeCreationDetails Details;


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
            Vector2 graphMousePosition;

            InvokeSelectedEntryEvent();

            CalculateGraphMousePosition();

            CreateNodes();

            return true;

            void InvokeSelectedEntryEvent()
            {
                DSTreeEntrySelectedEvent.Invoke();
            }

            void CalculateGraphMousePosition()
            {
                // The 2d direction from mouse screen position to window center position.
                Vector2 preWindowCenterDir;
                if (isUpdatePositionSelectEntry)
                {
                    // Update mouse position again.
                    preWindowCenterDir = DSGraphView.GetCurrentEventMousePosition() - DsWindow.position.position;
                }
                else
                {
                    // Use the mouse posiiont which was cached earlier.
                    preWindowCenterDir = context.screenMousePosition - DsWindow.position.position;
                }
                
                // Get the screen space mouse position and convert its coordinates to window(?) space.
                Vector2 postWindowCenterDir = DsWindow.rootVisualElement.ChangeCoordinatesTo
                (
                    DsWindow.rootVisualElement.parent,
                    preWindowCenterDir
                );

                // And calculate its position in the graph view.
                graphMousePosition = GraphView.contentViewContainer.WorldToLocal(postWindowCenterDir);
            }

            void CreateNodes()
            {
                // Local reference of the node that we're creating.
                DSNodeBase createdNode = null;

                // Retrieves the underlying node type by the convering the entryId inside the search entry.
                N_NodeType selectedNodeType = (N_NodeType)((DSNodeCreationEntry)searchTreeEntry).EntryId;

                // Create it under the graph position that we has just calculated.
                switch (selectedNodeType)
                {
                    case N_NodeType.Start:
                        createdNode = new DSStartNode(graphMousePosition, GraphView);
                        break;
                    case N_NodeType.Dialogue:
                        createdNode = new DSDialogueNode(graphMousePosition, GraphView);
                        break;
                    case N_NodeType.Option:
                        createdNode = new DSOptionNode(graphMousePosition, GraphView);
                        break;
                    case N_NodeType.Event:
                        createdNode = new DSEventNode(graphMousePosition, GraphView);
                        break;
                    case N_NodeType.Branch:
                        createdNode = new DSBranchNode(graphMousePosition, GraphView);
                        break;
                    case N_NodeType.End:
                        createdNode = new DSEndNode(graphMousePosition, GraphView);
                        break;
                }

                // Invoke the ManualCreatedAction from the node we created.
                createdNode.ManualCreatedAction(Details);
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


        // ----------------------------- Open Window Services -----------------------------
        /// <summary>
        /// Open the node creation request search window.
        /// </summary>
        /// <param name="screenPositionToShow">The screen position to use to show the search window.</param>
        public void Open(Vector2 screenPositionToShow)
        {
            // Show window.
            SearchWindow.Open(new SearchWindowContext(screenPositionToShow), this);
        }
    }
}