using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        [Header("Refs.")]
        private DialogueEditorWindow dsWindow;
        private DSGraphView graphView;

        private Texture2D fakeEntryPic;

        #region Setup.
        public void PostSetup(DialogueEditorWindow dsWindow, DSGraphView graphView)
        {
            this.dsWindow = dsWindow;
            this.graphView = graphView;

            // Icon image that we kinda don't use.
            // However use it to create space left of the text.
            // TODO: find a better way.
            fakeEntryPic = new Texture2D(1, 1);
            fakeEntryPic.SetPixel(0, 0, new Color(0, 0, 0, 0));
            fakeEntryPic.Apply();
        }
        #endregion

        #region Create SearchTree Callback.
        /// This method is invoked when the SearchWindow first opens and when it is reloaded.
        /// List<SearchTreeEntry> Returns the list of SearchTreeEntry objects displayed in the search window.
        /// Read More https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Experimental.GraphView.ISearchWindowProvider.CreateSearchTree.html
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> searchTrees = new List<SearchTreeEntry>
            {
                new SearchTreeGroupEntry(new GUIContent("Dialogue Editor"), 0),
                new SearchTreeGroupEntry(new GUIContent("Nodes"), 1),

                AddNodeSearch("Start Node", new StartNode()),
                AddNodeSearch("Dialogue Node", new DialogueNode()),
                AddNodeSearch("Choice Node", new ChoiceNode()),
                AddNodeSearch("Event Node", new EventNode()),
                AddNodeSearch("Branch Node", new BranchNode()),
                AddNodeSearch("End Node", new EndNode())
            };

            return searchTrees;
        }

        SearchTreeEntry AddNodeSearch(string _name, BaseNode _baseNode)
        {
            SearchTreeEntry searchTree = new SearchTreeEntry(new GUIContent(_name, fakeEntryPic))
            {
                level = 2,
                userData = _baseNode
            };

            return searchTree;
        }
        #endregion

        #region Select Entry Callback.
        /// Callback method provided by Unity, fired when user selects an entry in the search tree list.
        /// Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.ISearchWindowProvider.OnSelectEntry.html
        public bool OnSelectEntry(SearchTreeEntry _searchTreeEntry, SearchWindowContext _context)
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
                    dsWindow.rootVisualElement.parent, _context.screenMousePosition - dsWindow.position.position
                );

                // Now we use mouse position to calculate where it is in the graph view
                Vector2 graphMousePosition = graphView.contentViewContainer.WorldToLocal(mousePosition);

                CreateNodeByType(_searchTreeEntry, graphMousePosition);
            }
        }

        void CreateNodeByType(SearchTreeEntry _searchTreeEntry, Vector2 _pos)
        {
            switch (_searchTreeEntry.userData)
            {
                case StartNode node:
                    graphView.CreateStartNode(_pos);
                    break;
                case DialogueNode node:
                    graphView.CreateDialogueNode(_pos);
                    break;
                case ChoiceNode node:
                    graphView.CreateChoiceNode(_pos);
                    break;
                case EventNode node:
                    graphView.CreateEventNode(_pos);
                    break;
                case BranchNode node:
                    graphView.CreateBranchNode(_pos);
                    break;
                case EndNode node:
                    graphView.CreateEndNode(_pos);
                    break;
            }
        }
        #endregion
    }
}