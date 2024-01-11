using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class NodeCreationRequestSearchWindowPresenter
    {
        /// <summary>
        /// Create a new node creation request search window.
        /// </summary>
        /// <returns>A new node creation request search window.</returns>
        public static SearchWindowBase CreateWindow()
        {
            SearchWindowBase window;
            List<SearchTreeEntry> searchTreeEntries;

            CreateSearchTreeEntries();

            CreateWindow();

            return window;

            void CreateSearchTreeEntries()
            {
                var presenter = new NodeCreateEntryPresenter();

                searchTreeEntries = new()
                {
                    // Ancestor entry.
                    presenter.CreateAncestorEntry(),
                    
                    // Family entry.
                    presenter.CreateNodeFamilyEntry(entryLevel: 1),

                    // Child entry.
                    presenter.CreateBooleanNodeChildEntry(entryLevel:2),
                    presenter.CreateDialogueNodeChildEntry(entryLevel: 2),
                    presenter.CreateEndNodeChildEntry(entryLevel:2),
                    presenter.CreateEventNodeChildEntry(entryLevel:2),
                    presenter.CreateOptionBranchNodeChildEntry(entryLevel:2),
                    presenter.CreateOptionRootNodeChildEntry(entryLevel:2),
                    presenter.CreatePreviewNodeChildEntry(entryLevel: 2),
                    presenter.CreateStartNodeChildEntry(entryLevel:2),
                    presenter.CreateStoryNodeChildEntry(entryLevel:2),
                };
            }

            void CreateWindow()
            {
                window = SearchWindowPresenter.CreateWindow(searchTreeEntries);
            }
        }
    }
}