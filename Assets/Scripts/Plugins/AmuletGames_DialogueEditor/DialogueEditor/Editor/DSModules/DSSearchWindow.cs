using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        DSGraphView graphView;


        /// <summary>
        /// Reference of the dialogue system's editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Invisible icon that used to create space on each search tree entry besides their name tag.
        /// </summary>
        Texture2D searchTreeEntryIcon;


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to initialize internal fields, create a new search tree
        /// <br>and setups each search tree entry within it.</br>
        /// <para></para>
        /// <br>It's called by graph view module and executed after the graph view's own post setups are done.</br>
        /// </summary>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        public void PostSetup(DSGraphView graphView, DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;
            this.graphView = graphView;

            
            searchTreeEntryIcon = new Texture2D(1, 1);
            searchTreeEntryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
            searchTreeEntryIcon.Apply();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Executed when user selects an entry in the search tree list.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html</para>
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="context">Contextual data to pass to the search window when it is first created.</param>
        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            // Set the window has unsaved changes.
            InvokeSelectedEntryEvent();

            // TODO: Check if searchTreeEntry userData is node or other maybe node group.
            OnSelectCreateNode();

            return true;

            void InvokeSelectedEntryEvent()
            {
                DSTreeEntrySelectedEvent.Invoke();
            }

            void OnSelectCreateNode()
            {
                // Get mouse position on the screen.
                Vector2 mousePosition = dsWindow.rootVisualElement.ChangeCoordinatesTo
                (
                    dsWindow.rootVisualElement.parent, context.screenMousePosition - dsWindow.position.position
                );

                // Now we use mouse position to calculate where it is in the graph view
                Vector2 graphMousePosition = graphView.contentViewContainer.WorldToLocal(mousePosition);

                CreateNodeByType(searchTreeEntry, graphMousePosition);
            }
        }


        /// <summary>
        /// Ask DSNodesMaker to create different new nodes based on the search tree entry that user selected
        /// <br>and the specified 2d position on the graph.</br>
        /// </summary>
        /// <param name="searchTreeEntry">The selected entry.</param>
        /// <param name="position">The 2d graph position to use when creating a new node on the graph.</param>
        void CreateNodeByType(SearchTreeEntry searchTreeEntry, Vector2 position)
        {
            switch (searchTreeEntry.userData)
            {
                case N_NodeType.Start:
                    DSNodesMaker.CreateStartNode(position, graphView);
                    break;
                case N_NodeType.Dialogue:
                    DSNodesMaker.CreateDialogueNode(position, graphView);
                    break;
                case N_NodeType.Choice:
                    DSNodesMaker.CreateChoiceNode(position, graphView);
                    break;
                case N_NodeType.Event:
                    DSNodesMaker.CreateEventNode(position, graphView);
                    break;
                case N_NodeType.Branch:
                    DSNodesMaker.CreateBranchNode(position, graphView);
                    break;
                case N_NodeType.End:
                    DSNodesMaker.CreateEndNode(position, graphView);
                    break;
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
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> searchTrees = new List<SearchTreeEntry>
            {
                new SearchTreeGroupEntry(new GUIContent("Dialogue Editor"), 0),
                new SearchTreeGroupEntry(new GUIContent("Nodes"), 1),

                AddNodeSearch("Start Node", N_NodeType.Start),
                AddNodeSearch("Dialogue Node", N_NodeType.Dialogue),
                AddNodeSearch("Choice Node", N_NodeType.Choice),
                AddNodeSearch("Event Node", N_NodeType.Event),
                AddNodeSearch("Branch Node", N_NodeType.Branch),
                AddNodeSearch("End Node", N_NodeType.End)
            };

            return searchTrees;
        }


        /// <summary>
        /// Add a new node search tree entry with specified name and node's type.
        /// </summary>
        /// <param name="entryName">Name of the new node search tree entry.</param>
        /// <param name="entryNodeType">Type of the node that the entry is about to create.</param>
        /// <returns>A new node search tree entry that is ready to be added to the search tree window.</returns>
        SearchTreeEntry AddNodeSearch(string entryName, N_NodeType entryNodeType)
        {
            return new SearchTreeEntry(new GUIContent(entryName, searchTreeEntryIcon))
            {
                level = 2,
                userData = entryNodeType
            };
        }
    }
}