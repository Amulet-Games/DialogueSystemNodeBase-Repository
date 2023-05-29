using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeCreateWindowBase : EditorWindow, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        public DialogueEditorWindow DsWindow;


        /// <summary>
        /// Reference of the serialize handler.
        /// </summary>
        public SerializeHandler SerializeHandler;


        /// <summary>
        /// Reference of the node create details.
        /// </summary>
        public NodeCreateDetails Details;


        /// <summary>
        /// Will the window update the cached screen mouse position when selected a node create entry?
        /// </summary>
        public bool IsUpdatePositionSelectEntry;


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

            PostUpdateCreateDetails();

            CreateNodes();

            return true;

            void InvokeSelectedEntryEvent()
            {
                SearchTreeEntrySelectedEvent.Invoke();
            }

            void CalculateGraphMousePosition()
            {
                // The 2d direction from mouse screen position to window center position.
                Vector2 preWindowCenterDir;
                if (IsUpdatePositionSelectEntry)
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

            void PostUpdateCreateDetails()
            {
                // Update the position of where the node is going to be created.
                Details.SetPositionCreate(value: createPosition);
            }

            void CreateNodes()
            {
                // Retrieves the underlying node type by conversing the entryId inside the search entry.
                var selectedNodeType = (N_NodeType)((NodeCreateEntry)searchTreeEntry).EntryId;
                switch (selectedNodeType)
                {
                    case N_NodeType.Boolean:
                        var booleanNode = new BooleanNode(GraphViewer);
                        booleanNode.CreatedAction();
                        booleanNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.Dialogue:
                        var dialogueNode = new DialogueNode(GraphViewer);
                        dialogueNode.CreatedAction();
                        dialogueNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.End:
                        var endNode = new EndNode(GraphViewer);
                        endNode.CreatedAction();
                        endNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.Event:
                        var eventNode = new EventNode(GraphViewer);
                        eventNode.CreatedAction();
                        eventNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.OptionBranch:
                        var optionBranchNode = new OptionBranchNode(GraphViewer);
                        optionBranchNode.CreatedAction();
                        optionBranchNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.OptionRoot:
                        var optionRootNode = new OptionRootNode(GraphViewer);
                        optionRootNode.CreatedAction();
                        optionRootNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.Preview:
                        var previewNode = new PreviewNode(GraphViewer);
                        previewNode.CreatedAction();
                        previewNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.Start:
                        var startNode = new StartNode(GraphViewer);
                        startNode.CreatedAction();
                        startNode.Presenter.SetNodePosition(Details);
                        break;
                    case N_NodeType.Story:
                        var storyNode = new StoryNode(GraphViewer);
                        storyNode.CreatedAction();
                        storyNode.Presenter.SetNodePosition(Details);
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
        /// Open the node create request search window.
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