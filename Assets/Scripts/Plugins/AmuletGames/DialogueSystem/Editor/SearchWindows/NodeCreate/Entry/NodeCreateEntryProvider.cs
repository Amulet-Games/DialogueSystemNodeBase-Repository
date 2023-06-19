using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// A class that has implemented different types of node create entries as properties,
    /// <br>and allows other classes to retrieve them.</br>
    /// </summary>
    public class NodeCreateEntryProvider
    {
        /// <summary>
        /// Is this class has already been setup?
        /// </summary>
        static bool isSetup;


        /// <summary>
        /// List of entries that have included every nodes that can be created on the graph,
        /// <br>no matter which elements are the nodes are belong to, by channels or default.</br>
        /// </summary>
        public static List<SearchTreeEntry> NodeCreateRequestEntries;


        /// <summary>
        /// Default node's input connector create entries.
        /// </summary>
        public static List<SearchTreeEntry> DefaultNodeInputEntries;


        /// <summary>
        /// Default node's output connector create entries.
        /// </summary>
        public static List<SearchTreeEntry> DefaultNodeOutputEntries;


        /// <summary>
        /// Option channel's output connector create entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelOutputEntries;


        /// <summary>
        /// Option channel's input connector create entries.
        /// </summary>
        public static List<SearchTreeEntry> OptionChannelInputEntries;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void SetupNodeCreateWindowEntries()
        {
            if (isSetup)
                return;

            var presenter = new NodeCreateEntryPresenter();
            var ancestorEntry = presenter.CreateAncestorEntry();

            NodeCreateRequestEntries = new()
            {
                // Ancestor entry.
                ancestorEntry,

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

            // Node Create Connector Entries.
            {
                var booleanNodeChildEntry = presenter.CreateBooleanNodeChildEntry(entryLevel: 1);
                var dialogueNodeChildEntry = presenter.CreateDialogueNodeChildEntry(entryLevel: 1);
                var endNodeChildEntry = presenter.CreateEndNodeChildEntry(entryLevel: 1);
                var eventNodeChildEntry = presenter.CreateEventNodeChildEntry(entryLevel: 1);
                var optionBranchNodeChildEntry = presenter.CreateOptionBranchNodeChildEntry(entryLevel: 1);
                var optionRootNodeChildEntry = presenter.CreateOptionRootNodeChildEntry(entryLevel: 1);
                var previewNodeChildEntry = presenter.CreatePreviewNodeChildEntry(entryLevel: 1);
                var startNodeChildEntry = presenter.CreateStartNodeChildEntry(entryLevel: 1);
                var storyNodeChildEntry = presenter.CreateStoryNodeChildEntry(entryLevel: 1);

                // Default Connector
                DefaultNodeInputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    dialogueNodeChildEntry,
                    eventNodeChildEntry,
                    optionBranchNodeChildEntry,
                    previewNodeChildEntry,
                    startNodeChildEntry,
                    storyNodeChildEntry
                };
                DefaultNodeOutputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    booleanNodeChildEntry,
                    dialogueNodeChildEntry,
                    endNodeChildEntry,
                    eventNodeChildEntry,
                    optionRootNodeChildEntry,
                    previewNodeChildEntry,
                    storyNodeChildEntry
                };

                // Option Connector
                OptionChannelInputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    optionRootNodeChildEntry
                };
                OptionChannelOutputEntries = new()
                {
                    // Ancestor entry.
                    ancestorEntry,

                    // Child entry.
                    optionBranchNodeChildEntry
                };
            }

            isSetup = true;
        }
    }
}